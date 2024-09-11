using Defender.BudgetTracker.Application.Common.Interfaces;
using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;

namespace Defender.BudgetTracker.Application.Services;

public class Service(
    IDomainModelRepository accountInfoRepository) : IService
{
    public Task DoService()
    {
        throw new NotImplementedException();
    }
}
