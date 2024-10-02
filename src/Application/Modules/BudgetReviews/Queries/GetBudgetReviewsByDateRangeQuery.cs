using FluentValidation;
using MediatR;
using Defender.BudgetTracker.Domain.Entities.Reviews;
using Defender.BudgetTracker.Application.Common.Interfaces.Services;

namespace Defender.BudgetTracker.Application.Modules.BudgetReviews.Queries;

public record GetBudgetReviewsByDateRangeQuery : IRequest<List<BudgetReview>>
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
};

public sealed class GetBudgetReviewsByDateRangeQueryValidator 
    : AbstractValidator<GetBudgetReviewsByDateRangeQuery>
{
    public GetBudgetReviewsByDateRangeQueryValidator()
    {
    }
}

public sealed class GetBudgetReviewsByDateRangeQueryHandler(
        IBudgetReviewService budgetReviewService)
    : IRequestHandler<GetBudgetReviewsByDateRangeQuery, List<BudgetReview>>
{

    public Task<List<BudgetReview>> Handle(
        GetBudgetReviewsByDateRangeQuery request,
        CancellationToken cancellationToken)
    {
        return budgetReviewService
            .GetCurrentUserBudgetReviewsAsync(request.StartDate,request.EndDate);
    }
}
