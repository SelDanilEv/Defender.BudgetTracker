using Defender.BudgetTracker.Application.Configuration.Options;
using Defender.BudgetTracker.Application.Helpers.LocalSecretHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Defender.BudgetTracker.Application.Configuration.Exstension;

public static class ServiceOptionsExtensions
{
    public static IServiceCollection AddApplicationOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<ExchangeRatesApiOptions>(
            configuration.GetSection(nameof(ExchangeRatesApiOptions)));

        services.PostConfigure<ExchangeRatesApiOptions>((opt) =>
        {
            opt.AccessKey = LocalSecretsHelper.GetSecretSync(LocalSecret.ExchangeRatesApiAccessKey, true);
        });

        return services;
    }
}