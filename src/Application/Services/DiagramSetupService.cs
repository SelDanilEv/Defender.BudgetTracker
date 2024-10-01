using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Application.Models.DiagramSetups;
using Defender.BudgetTracker.Domain.Entities.DiagramSetup;
using Defender.Common.Interfaces;

namespace Defender.BudgetTracker.Application.Services;

public class DiagramSetupService(
    IDiagramSetupRepository diagramSetupRepository,
    ICurrentAccountAccessor currentAccountAccessor) : IDiagramSetupService
{
    public Task<DiagramSetup> GetCurrentUserDiagramSetupAsync()
    {
        return diagramSetupRepository
            .GetDiagramSetupByUserIdAsync(currentAccountAccessor.GetAccountId());
    }

    public Task<DiagramSetup> UpdateDiagramSetupAsync(UpdateMainDiagramSetupRequest request)
    {
        var currentUserId = currentAccountAccessor.GetAccountId();

        return diagramSetupRepository.SetDiagramSetupAsync(
            request.MapToDiagramSetup(currentUserId));
    }
}
