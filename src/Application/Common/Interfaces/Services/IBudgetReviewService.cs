using Defender.BudgetTracker.Application.Models.BudgetReview;
using Defender.BudgetTracker.Domain.Entities.Reviews;
using Defender.Common.DB.Pagination;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Services;

public interface IBudgetReviewService
{
    Task<PagedResult<BudgetReview>> GetCurrentUserBudgetReviewsAsync(PaginationRequest paginationRequest);

    Task<List<BudgetReview>> GetCurrentUserBudgetReviewsAsync(DateOnly startDate, DateOnly endDate);

    Task<BudgetReview> GetBudgetReviewTemplateAsync(DateOnly? date);

    Task<BudgetReview> PublishBudgetReviewAsync(PublishBudgetReviewRequest position);

    Task<Guid> DeleteBudgetReviewAsync(Guid positionId);
}
