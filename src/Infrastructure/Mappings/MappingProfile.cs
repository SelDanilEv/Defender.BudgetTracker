using Amazon.Auth.AccessControlPolicy;
using AutoMapper;
using Defender.BudgetTracker.Domain.Entities.Rates;
using Defender.BudgetTracker.Domain.Enums;
using Defender.BudgetTracker.Infrastructure.Models;
using Defender.Common.Helpers;
using Defender.Common.Mapping;

namespace Defender.BudgetTracker.Infrastructure.Mappings;

public class MappingProfile : BaseMappingProfile
{
    public MappingProfile()
    {
        //CreateMap<Clients.UserManagementClient.UserDto, Common.DTOs.UserDto>();
        CreateMap<HistoricalExchangeRatesResponse, HistoricalExchangeRates>()
            .ForMember(dest => dest.Base, opt => opt.MapFrom(src => src.Base))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateOnly.Parse(src.Date)));

        CreateMap<HistoricalExchangeRates, RatesModel>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.BaseCurrency, opt => opt.MapFrom(src =>
                MappingHelper.MapEnum(src.Base, Currency.Unknown)))
            .ForMember(dest => dest.Rates, opt => opt.MapFrom(src => MapRates(src.Rates)));
    }


    private Dictionary<Currency, decimal> MapRates(Dictionary<string, decimal> rates)
    {
        return rates
            .Where(rate => Enum.TryParse<Currency>(rate.Key, out _))
            .ToDictionary(
                rate => MappingHelper.MapEnum(rate.Key, Currency.Unknown),
                rate => rate.Value
            );
    }
}

