using AutoMapper;
using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Application.Common.Interfaces.Wrapper;
using Defender.BudgetTracker.Domain.Entities.Rates;

namespace Defender.BudgetTracker.Application.Services;

public class RatesModelService(
    IHistoricalExchangeRatesRepository ratesRepository,
    IExchangeRatesApiWrapper exchangeRatesApiWrapper,
    IMapper mapper) : IRatesModelService
{
    public async Task<RatesModel> GetRatesModelAsync(DateOnly date)
    {
        var rates = await ratesRepository.GetHistoricalExchangeRatesByDateAsync(date);

        if (rates == null)
        {
            rates = await exchangeRatesApiWrapper.SearchRatesByDate(date);

            _ = ratesRepository.AddHistoricalExchangeRatesAsync(rates);
        }

        var model = mapper.Map<RatesModel>(rates);

        return model;
    }
}
