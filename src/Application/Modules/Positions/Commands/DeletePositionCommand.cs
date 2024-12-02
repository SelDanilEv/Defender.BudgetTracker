using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using FluentValidation;
using MediatR;

namespace Defender.BudgetTracker.Application.Modules.Positions.Commands;

public record DeletePositionCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
};

public sealed class DeletePositionCommandValidator : AbstractValidator<DeletePositionCommand>
{
    public DeletePositionCommandValidator()
    {
    }
}

public sealed class DeletePositionCommandHandler(IPositionService positionService)
    : IRequestHandler<DeletePositionCommand, Guid>
{

    public Task<Guid> Handle(
        DeletePositionCommand request,
        CancellationToken cancellationToken)
    {
        return positionService.DeletePositionAsync(request.Id);
    }
}
