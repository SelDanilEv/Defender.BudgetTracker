using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Domain.Entities.Reviews;
using Defender.Common.DB.Pagination;
using FluentValidation;
using MediatR;

namespace Defender.BudgetTracker.Application.Modules.BudgetReviews.Queries;

public record GetBudgetReviewsQuery : PaginationRequest, IRequest<PagedResult<BudgetReview>>
{
};

public sealed class GetBudgetReviewsQueryValidator : AbstractValidator<GetBudgetReviewsQuery>
{
    public GetBudgetReviewsQueryValidator()
    {
    }
}

public sealed class GetBudgetReviewsQueryHandler(
        IBudgetReviewService budgetReviewService)
    : IRequestHandler<GetBudgetReviewsQuery, PagedResult<BudgetReview>>
{

    public Task<PagedResult<BudgetReview>> Handle(
        GetBudgetReviewsQuery request,
        CancellationToken cancellationToken)
    {
        return budgetReviewService.GetCurrentUserBudgetReviewsAsync(request);
    }
}
