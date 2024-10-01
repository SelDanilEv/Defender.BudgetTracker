using Defender.BudgetTracker.Domain.Entities.DiagramSetup;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Repositories;

public interface IDiagramSetupRepository
{
    Task<DiagramSetup> GetDiagramSetupByUserIdAsync(Guid userId);
    Task<DiagramSetup> SetDiagramSetupAsync(DiagramSetup setup);
}
