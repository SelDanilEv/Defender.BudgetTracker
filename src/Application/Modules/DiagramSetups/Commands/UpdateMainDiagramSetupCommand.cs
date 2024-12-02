using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Application.Models.DiagramSetups;
using Defender.BudgetTracker.Domain.Entities.DiagramSetup;
using Defender.Common.Errors;
using Defender.Common.Extension;
using FluentValidation;
using MediatR;

namespace Defender.BudgetTracker.Application.Modules.DiagramSetups.Commands;

public record UpdateMainDiagramSetupCommand : UpdateMainDiagramSetupRequest, IRequest<DiagramSetup>
{

};

public sealed class UpdateMainDiagramSetupCommandValidator : AbstractValidator<UpdateMainDiagramSetupCommand>
{
    public UpdateMainDiagramSetupCommandValidator()
    {
        RuleFor(x => x.LastMonths)
            .Must(x => x > 0)
            .WithMessage(ErrorCode.VL_BTS_NumberOfLatestMonthsMustBePositive);
    }
}

public sealed class UpdateMainDiagramSetupCommandHandler(
        IDiagramSetupService diagramSetupService)
    : IRequestHandler<UpdateMainDiagramSetupCommand, DiagramSetup>
{

    public Task<DiagramSetup> Handle(
        UpdateMainDiagramSetupCommand request,
        CancellationToken cancellationToken)
    {
        return diagramSetupService.UpdateDiagramSetupAsync(request);
    }
}
