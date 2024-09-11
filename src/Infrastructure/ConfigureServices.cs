using System.Reflection;
using AutoMapper;
using Defender.Common.Clients.Identity;
using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Application.Common.Interfaces.Wrapper;
using Defender.BudgetTracker.Application.Configuration.Options;
using Defender.BudgetTracker.Infrastructure.Clients.Service;
using Defender.BudgetTracker.Infrastructure.Repositories.DomainModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
            .RegisterClientWrappers();

        return services;
    }

    private static IServiceCollection RegisterClientWrappers(this IServiceCollection services)
    {
        services.AddTransient<IServiceWrapper, ServiceWrapper>();

        return services;
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IDomainModelRepository, DomainModelRepository>();

        return services;
    }

    private static IServiceCollection RegisterApiClients(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.RegisterIdentityClient(
            (serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(serviceProvider.GetRequiredService<IOptions<ServiceOptions>>().Value.Url);
            });

        return services;
    }

}
