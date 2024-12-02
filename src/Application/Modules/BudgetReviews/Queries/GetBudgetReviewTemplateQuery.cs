using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Domain.Entities.Reviews;
using FluentValidation;
using MediatR;

namespace Defender.BudgetTracker.Application.Modules.BudgetReviews.Queries;

public record GetBudgetReviewTemplateQuery : IRequest<BudgetReview>
{
    public DateOnly? Date { get; set; }
};

public sealed class GetBudgetReviewTemplateQueryValidator : AbstractValidator<GetBudgetReviewTemplateQuery>
{
    public GetBudgetReviewTemplateQueryValidator()
    {
    }
}

public sealed class GetBudgetReviewTemplateQueryHandler(
        IBudgetReviewService budgetReviewService)
    : IRequestHandler<GetBudgetReviewTemplateQuery, BudgetReview>
{

    public Task<BudgetReview> Handle(
        GetBudgetReviewTemplateQuery request,
        CancellationToken cancellationToken)
    {
        return budgetReviewService.GetBudgetReviewTemplateAsync(request.Date);
    }
}
