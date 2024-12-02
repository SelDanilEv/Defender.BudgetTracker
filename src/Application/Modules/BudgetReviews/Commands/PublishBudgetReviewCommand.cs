using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Application.Models.BudgetReview;
using Defender.BudgetTracker.Domain.Entities.Reviews;
using Defender.Common.Errors;
using Defender.Common.Extension;
using FluentValidation;
using MediatR;

namespace Defender.BudgetTracker.Application.Modules.BudgetReviews.Commands;

public record PublishBudgetReviewCommand : PublishBudgetReviewRequest, IRequest<BudgetReview>
{
};

public sealed class PublishBudgetReviewCommandValidator : AbstractValidator<PublishBudgetReviewCommand>
{
    public PublishBudgetReviewCommandValidator()
    {
        RuleFor(x => x.ReviewedPositions)
            .Must(x => x.Count > 0)
            .WithMessage(ErrorCode.VL_BTS_NumberOfPositionsMustBePositive);

    }
}

public sealed class PublishBudgetReviewCommandHandler(
        IBudgetReviewService budgetReviewService)
    : IRequestHandler<PublishBudgetReviewCommand, BudgetReview>
{
    public Task<BudgetReview> Handle(
        PublishBudgetReviewCommand request,
        CancellationToken cancellationToken)
    {
        return budgetReviewService.PublishBudgetReviewAsync(request);
    }
}
