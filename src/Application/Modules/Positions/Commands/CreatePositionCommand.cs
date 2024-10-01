using FluentValidation;
using MediatR;
using Defender.BudgetTracker.Application.Models.Positions;
using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.BudgetTracker.Domain.Enums;
using Defender.Common.Errors;
using Defender.Common.Extension;
using Defender.BudgetTracker.Application.Common.Interfaces.Services;

namespace Defender.BudgetTracker.Application.Modules.Positions.Commands;

public record CreatePositionCommand : CreatePositionRequest, IRequest<Position>
{
};

public sealed class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
{
    public CreatePositionCommandValidator()
    {
        RuleFor(x => x.Currency)
            .NotEqual(Currency.Unknown)
            .WithMessage(ErrorCode.VL_BTS_InvalidCurrency);

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(ErrorCode.VL_BTS_InvalidPositionName);

    }
}

public sealed class CreatePositionCommandHandler(
        IPositionService positionService)
    : IRequestHandler<CreatePositionCommand, Position>
{

    public Task<Position> Handle(
        CreatePositionCommand request,
        CancellationToken cancellationToken)
    {
        return positionService.CreatePositionAsync(request);
    }
}
