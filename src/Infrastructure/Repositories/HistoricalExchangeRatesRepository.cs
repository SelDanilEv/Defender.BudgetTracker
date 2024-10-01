using Defender.Common.Configuration.Options;
using Defender.Common.DB.Repositories;
using Microsoft.Extensions.Options;
using Defender.Common.DB.Model;
using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Domain.Entities.Rates;

namespace Defender.BudgetTracker.Infrastructure.Repositories;

public class HistoricalExchangeRatesRepository :
    BaseMongoRepository<HistoricalExchangeRates>, IHistoricalExchangeRatesRepository
{
    public HistoricalExchangeRatesRepository(
        IOptions<MongoDbOptions> mongoOption) : base(mongoOption.Value)
    {
    }

    public Task<HistoricalExchangeRates> GetHistoricalExchangeRatesByDateAsync(
        DateOnly date)
    {
        var filter = FindModelRequest<HistoricalExchangeRates>
            .Init(x => x.Date, date);

        return GetItemAsync(filter);
    }

    public Task<HistoricalExchangeRates> AddHistoricalExchangeRatesAsync(
        HistoricalExchangeRates rates)
    {
        var filter = FindModelRequest<HistoricalExchangeRates>
            .Init(x => x.Date, rates.Date);

        return ReplaceItemAsync(rates, filter);
    }
}
