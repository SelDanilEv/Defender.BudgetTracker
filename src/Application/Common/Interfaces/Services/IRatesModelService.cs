using Defender.BudgetTracker.Domain.Entities.Rates;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Services;

public interface IRatesModelService
{
    Task<RatesModel> GetRatesModelAsync(DateOnly date);
}
