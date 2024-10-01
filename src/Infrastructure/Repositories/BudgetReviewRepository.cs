using Defender.Common.Configuration.Options;
using Defender.Common.DB.Repositories;
using Microsoft.Extensions.Options;
using Defender.Common.DB.Model;
using Defender.Common.DB.Pagination;
using Defender.BudgetTracker.Domain.Entities.Reviews;
using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;

namespace Defender.BudgetTracker.Infrastructure.Repositories;

public class BudgetReviewRepository : BaseMongoRepository<BudgetReview>, IBudgetReviewRepository
{
    public BudgetReviewRepository(
        IOptions<MongoDbOptions> mongoOption) : base(mongoOption.Value)
    {
    }

    public Task<PagedResult<BudgetReview>> GetBudgetReviewsAsync(
        PaginationRequest pagination,
        Guid userId)
    {
        var findRequest = FindModelRequest<BudgetReview>
            .Init(x=> x.UserId, userId)
            .Sort(x => x.Date, SortType.Desc);

        var settings = PaginationSettings<BudgetReview>
            .FromPaginationRequest(pagination);

        settings.SetupFindOptions(findRequest);

        return GetItemsAsync(settings);
    }

    public Task<BudgetReview> GetBudgetReviewAsync(
        Guid userId, DateOnly date)
    {
        var findRequest = FindModelRequest<BudgetReview>
            .Init(x => x.UserId, userId)
            .And(x => x.Date, date);

        return GetItemAsync(findRequest);
    }

    public Task<BudgetReview> GetBudgetReviewAsync(
        Guid reviewId)
    {
        return GetItemAsync(reviewId);
    }

    public Task<BudgetReview> GetLatestBudgetReviewAsync(Guid userId)
    {
        var findRequest = FindModelRequest<BudgetReview>
            .Init(x => x.UserId, userId)
            .Sort(x => x.Date, SortType.Desc);

        return GetItemAsync(findRequest);
    }

    public async Task<List<BudgetReview>> GetBudgetReviewsAsync(
        Guid userId, DateOnly startDate, DateOnly endDate)
    {
        var findRequest = FindModelRequest<BudgetReview>
            .Init(x => x.UserId, userId)
            .And(x => x.Date, startDate, FilterType.Gte)
            .And(x => x.Date, endDate, FilterType.Lte)
            .Sort(x => x.Date, SortType.Desc);

        var settings = PaginationSettings<BudgetReview>
            .WithoutPagination();

        settings.SetupFindOptions(findRequest);

        var pagedResult = await GetItemsAsync(settings);

        return [.. pagedResult.Items];
    }


    public Task<BudgetReview> UpsertBudgetReviewAsync(BudgetReview review)
    {
        FindModelRequest<BudgetReview> filter = review.Id == Guid.Empty
            ? FindModelRequest<BudgetReview>
            .Init(r => r.UserId, review.UserId)
            .And(r => r.Date, review.Date)
            : FindModelRequest<BudgetReview>
                .Init(r => r.Id, review.Id);

        return ReplaceItemAsync(review, filter);
    }

    public Task DeleteBudgetReviewAsync(Guid BudgetReviewId)
    {
        return RemoveItemAsync(BudgetReviewId);
    }
}
