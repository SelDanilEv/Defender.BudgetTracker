using Defender.BudgetTracker.Domain.Entities.Reviews;
using Defender.Common.DB.Pagination;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Repositories;

public interface IBudgetReviewRepository
{
    Task<PagedResult<BudgetReview>> GetBudgetReviewsAsync(
        PaginationRequest pagination, Guid userId);

    Task<List<BudgetReview>> GetBudgetReviewsAsync(
        Guid userId, DateOnly startDate, DateOnly endDate);

    Task<BudgetReview> GetBudgetReviewAsync(Guid userId, DateOnly date);

    Task<BudgetReview> GetBudgetReviewAsync(Guid reviewId);

    Task<BudgetReview> GetLatestBudgetReviewAsync(Guid id);

    Task<BudgetReview> UpsertBudgetReviewAsync(BudgetReview review);

    Task DeleteBudgetReviewAsync(Guid reviewId);
}
