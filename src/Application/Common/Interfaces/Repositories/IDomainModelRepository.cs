using Defender.BudgetTracker.Domain.Entities;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Repositories;

public interface IDomainModelRepository
{
    Task<DomainModel> GetDomainModelByIdAsync(Guid id);
}
