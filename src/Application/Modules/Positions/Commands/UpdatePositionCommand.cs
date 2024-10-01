using FluentValidation;
using MediatR;
using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.BudgetTracker.Application.Models.Positions;
using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Application.Models.Groups;

namespace Defender.BudgetTracker.Application.Modules.Positions.Commands;

public record UpdatePositionCommand : UpdatePositionRequest, IRequest<Position>
{
};

public sealed class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
{
    public UpdatePositionCommandValidator()
    {
    }
}

public sealed class UpdatePositionCommandHandler(
        IPositionService positionService)
    : IRequestHandler<UpdatePositionCommand, Position>
{

    public Task<Position> Handle(
        UpdatePositionCommand request,
        CancellationToken cancellationToken)
    {
        return positionService.UpdatePositionAsync(request);
    }
}
