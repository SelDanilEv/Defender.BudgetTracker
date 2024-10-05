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
    public async Task<DiagramSetup> GetCurrentUserDiagramSetupAsync()
    {
        var diagramSetup = await diagramSetupRepository
            .GetDiagramSetupByUserIdAsync(currentAccountAccessor.GetAccountId());

        if (diagramSetup is null)
            diagramSetup = await UpdateDiagramSetupAsync(UpdateMainDiagramSetupRequest.DefaultRequest);

        return diagramSetup;
    }

    public Task<DiagramSetup> UpdateDiagramSetupAsync(UpdateMainDiagramSetupRequest request)
    {
        var currentUserId = currentAccountAccessor.GetAccountId();

        return diagramSetupRepository.SetDiagramSetupAsync(
            request.MapToDiagramSetup(currentUserId));
    }
}
