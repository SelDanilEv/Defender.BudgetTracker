using AutoMapper;
using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Application.Models.BudgetReview;
using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.BudgetTracker.Domain.Entities.Reviews;
using Defender.Common.DB.Pagination;
using Defender.Common.Interfaces;

namespace Defender.BudgetTracker.Application.Services;

public class BudgetReviewService(
    IBudgetReviewRepository budgetReviewRepository,
    IPositionService positionService,
    ICurrentAccountAccessor currentAccountAccessor,
    IRatesModelService ratesModelService,
    IMapper mapper)
    : IBudgetReviewService
{
    public Task<PagedResult<BudgetReview>> GetCurrentUserBudgetReviewsAsync(
        PaginationRequest paginationRequest)
    {
        var currentUserId = currentAccountAccessor.GetAccountId();

        return budgetReviewRepository.GetBudgetReviewsAsync(paginationRequest, currentUserId);
    }

    public Task<List<BudgetReview>> GetCurrentUserBudgetReviewsAsync(
        DateOnly startDate, DateOnly endDate)
    {
        var currentUserId = currentAccountAccessor.GetAccountId();

        return budgetReviewRepository.GetBudgetReviewsAsync(currentUserId, startDate, endDate);
    }

    public async Task<BudgetReview> GetBudgetReviewTemplateAsync(DateOnly? date)
    {
        date ??= DateOnly.FromDateTime(DateTime.UtcNow);
        var userId = currentAccountAccessor.GetAccountId();

        var getRatesTask = ratesModelService.GetRatesModelAsync(date.Value);

        var getPositionsTask = positionService.GetCurrentUserPositionsAsync(
            PaginationRequest.CreateWithoutPagination);

        var getLatestReviewTask = budgetReviewRepository.GetLatestBudgetReviewAsync(userId);


        var budgetReview = new BudgetReview
        {
            UserId = userId,
            Date = date.Value,
            RatesModel = await getRatesTask
        };

        var latestBudgetReviewPositions = (await getLatestReviewTask)?.Positions ?? [];

        budgetReview.Positions = (await getPositionsTask).Items.Select(
            r => ReviewedPosition
                .FromPosition(r, GetLatestReviewPosition(latestBudgetReviewPositions, r))
        ).ToList();

        return budgetReview;
    }

    public async Task<BudgetReview> PublishBudgetReviewAsync(
        PublishBudgetReviewRequest publishRequest)
    {
        var userId = currentAccountAccessor.GetAccountId();

        BudgetReview reviewToReplace = new()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Date = publishRequest.Date,
        };

        if (publishRequest.Id.HasValue)
        {
            var reviewById = await budgetReviewRepository
                .GetBudgetReviewAsync(publishRequest.Id.Value);

            if (reviewById is not null)
            {
                if (reviewById.Date == publishRequest.Date)
                {
                    reviewById.Positions = mapper
                        .Map<List<ReviewedPosition>>(publishRequest.ReviewedPositions);

                    return await budgetReviewRepository
                        .UpsertBudgetReviewAsync(reviewById);
                }

                reviewToReplace.Id = reviewById.Id;
            }
        }

        var reviewByDate = await budgetReviewRepository
            .GetBudgetReviewAsync(userId, publishRequest.Date);

        if (reviewByDate is not null)
        {
            reviewToReplace.RatesModel = reviewByDate.RatesModel;

            await budgetReviewRepository.DeleteBudgetReviewAsync(reviewByDate.Id);
        }
        else
        {
            reviewToReplace.RatesModel = await ratesModelService
                .GetRatesModelAsync(publishRequest.Date);
        }

        reviewToReplace.Positions = mapper
            .Map<List<ReviewedPosition>>(publishRequest.ReviewedPositions);

        return await budgetReviewRepository
            .UpsertBudgetReviewAsync(reviewToReplace);
    }


    public async Task<Guid> DeleteBudgetReviewAsync(
        Guid positionId)
    {
        await budgetReviewRepository.DeleteBudgetReviewAsync(positionId);

        return positionId;
    }

    private static long GetLatestReviewPosition(List<ReviewedPosition> positions, Position position)
        => positions
            .FirstOrDefault(x => x.Name == position.Name && x.Currency == position.Currency)?
            .Amount ?? 0;
}
