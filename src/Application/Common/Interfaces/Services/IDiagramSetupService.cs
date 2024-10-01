using Defender.BudgetTracker.Application.Models.DiagramSetups;
using Defender.BudgetTracker.Domain.Entities.DiagramSetup;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Services;

public interface IDiagramSetupService
{
    Task<DiagramSetup> GetCurrentUserDiagramSetupAsync();
    Task<DiagramSetup> UpdateDiagramSetupAsync(UpdateMainDiagramSetupRequest newSetup);
}
