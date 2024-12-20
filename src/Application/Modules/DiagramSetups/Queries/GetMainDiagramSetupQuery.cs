﻿using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Domain.Entities.DiagramSetup;
using FluentValidation;
using MediatR;

namespace Defender.BudgetTracker.Application.Modules.DiagramSetups.Queries;

public record GetMainDiagramSetupQuery : IRequest<DiagramSetup>
{
};

public sealed class GetMainDiagramSetupQueryValidator : AbstractValidator<GetMainDiagramSetupQuery>
{
    public GetMainDiagramSetupQueryValidator()
    {
    }
}

public sealed class GetMainDiagramSetupQueryHandler(
        IDiagramSetupService diagramSetupService)
    : IRequestHandler<GetMainDiagramSetupQuery, DiagramSetup>
{

    public Task<DiagramSetup> Handle(
        GetMainDiagramSetupQuery request,
        CancellationToken cancellationToken)
    {
        return diagramSetupService.GetCurrentUserDiagramSetupAsync();
    }
}
