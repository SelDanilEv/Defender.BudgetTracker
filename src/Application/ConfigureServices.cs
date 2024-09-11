using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Defender.BudgetTracker.Application.Common.Interfaces;
using Defender.BudgetTracker.Application.Services;

namespace Defender.BudgetTracker.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.RegisterServices();

        return services;
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IService, Service>();

        return services;
    }
}
