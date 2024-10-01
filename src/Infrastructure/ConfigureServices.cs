using System.Reflection;
using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Application.Common.Interfaces.Wrapper;
using Defender.BudgetTracker.Application.Configuration.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Defender.BudgetTracker.Infrastructure.Repositories;
using Defender.BudgetTracker.Infrastructure.Clients.ExchangeRatesApi;
using MongoDB.Bson.Serialization;
using Defender.BudgetTracker.Domain.Serialization;

namespace Defender.BudgetTracker.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

        services
            .RegisterRepositories()
            .RegisterApiClients(configuration)
            .RegisterClientWrappers()
            .RegisterMongoDbSerializers();

        return services;
    }

    private static IServiceCollection RegisterClientWrappers(this IServiceCollection services)
    {
        //services.AddTransient<IExchangeRatesApiWrapper, ExchangeRatesApiWrapper>();

        return services;
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IDiagramSetupRepository, DiagramSetupRepository>();
        services.AddSingleton<IPositionRepository, PositionRepository>();
        services.AddSingleton<IBudgetReviewRepository, BudgetReviewRepository>();
        services.AddSingleton<IGroupRepository, GroupRepository>();
        services.AddSingleton<IHistoricalExchangeRatesRepository, HistoricalExchangeRatesRepository>();

        return services;
    }

    private static IServiceCollection RegisterApiClients(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        //services.RegisterIdentityClient(
        //    (serviceProvider, client) =>
        //    {
        //        client.BaseAddress = new Uri(serviceProvider.GetRequiredService<IOptions<ExchangeRatesApiOptions>>().Value.Url);
        //    });

        services.AddHttpClient<IExchangeRatesApiWrapper, ExchangeRatesApiWrapper>((provider, client) =>
        {
            var options = provider.GetRequiredService<IOptions<ExchangeRatesApiOptions>>().Value;
            client.BaseAddress = new Uri(options.BaseUrl);
        });

        return services;
    }

    private static IServiceCollection RegisterMongoDbSerializers(
        this IServiceCollection services)
    {
        BsonSerializer.RegisterSerializer(new CustomSerializators());

        return services;
    }

}
