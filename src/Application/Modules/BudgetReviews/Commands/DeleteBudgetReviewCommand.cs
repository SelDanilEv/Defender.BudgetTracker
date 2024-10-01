using FluentValidation;
using MediatR;
using Defender.BudgetTracker.Application.Common.Interfaces.Services;

namespace Defender.BudgetTracker.Application.Modules.BudgetReviews.Commands;

public record DeleteBudgetReviewCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
};

public sealed class DeleteBudgetReviewCommandValidator : AbstractValidator<DeleteBudgetReviewCommand>
{
    public DeleteBudgetReviewCommandValidator()
    {
    }
}

public sealed class DeleteBudgetReviewCommandHandler(IBudgetReviewService budgetReviewService)
    : IRequestHandler<DeleteBudgetReviewCommand, Guid>
{

    public Task<Guid> Handle(
        DeleteBudgetReviewCommand request,
        CancellationToken cancellationToken)
    {
        return budgetReviewService.DeleteBudgetReviewAsync(request.Id);
    }
}
