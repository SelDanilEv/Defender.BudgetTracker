using Defender.BudgetTracker.Domain.Entities.Rates;
using Defender.BudgetTracker.Domain.Enums;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Wrapper;

public interface IExchangeRatesApiWrapper
{
    Task<HistoricalExchangeRates> SearchRatesByDate(DateOnly date, Currency baseCurrency = Currency.EUR);
}
