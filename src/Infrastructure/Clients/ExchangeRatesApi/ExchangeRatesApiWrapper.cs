using Defender.BudgetTracker.Application.Common.Interfaces.Wrapper;
using Defender.BudgetTracker.Domain.Enums;
using Defender.BudgetTracker.Application.Configuration.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Defender.Common.Exceptions;
using Defender.Common.Errors;
using AutoMapper;
using Defender.BudgetTracker.Infrastructure.Models;
using Defender.BudgetTracker.Domain.Entities.Rates;

namespace Defender.BudgetTracker.Infrastructure.Clients.ExchangeRatesApi;

public class ExchangeRatesApiWrapper : IExchangeRatesApiWrapper
{
    private readonly HttpClient _httpClient;
    private readonly ExchangeRatesApiOptions _options;
    private readonly IMapper _mapper;

    public ExchangeRatesApiWrapper(
        HttpClient httpClient,
        IOptions<ExchangeRatesApiOptions> options,
        IMapper mapper)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _mapper = mapper;
    }

    public async Task<HistoricalExchangeRates> SearchRatesByDate(DateOnly date, Currency baseCurrency = Currency.EUR)
    {
        string dateString = date.ToString("yyyy-MM-dd");
        string requestUri = $"{dateString}?access_key={_options.AccessKey}&base={baseCurrency}";

        HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        string responseContent = await response.Content.ReadAsStringAsync();

        var ratesResponse = JsonSerializer.Deserialize<HistoricalExchangeRatesResponse>(responseContent)
            ?? throw new NotFoundException(ErrorCode.ERAPI_RatesAreNotAvailable);

        return _mapper.Map<HistoricalExchangeRates>(ratesResponse);
    }
}
