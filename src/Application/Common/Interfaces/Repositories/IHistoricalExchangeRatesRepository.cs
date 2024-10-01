using Defender.BudgetTracker.Domain.Entities.Rates;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Repositories;

public interface IHistoricalExchangeRatesRepository
{
    Task<HistoricalExchangeRates> GetHistoricalExchangeRatesByDateAsync(
        DateOnly date);

    Task<HistoricalExchangeRates> AddHistoricalExchangeRatesAsync(HistoricalExchangeRates rates);
}
