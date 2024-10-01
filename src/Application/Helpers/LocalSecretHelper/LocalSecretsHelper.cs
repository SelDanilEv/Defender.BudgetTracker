using Defender.Common.Enums;
using Defender.Common.Helpers;

namespace Defender.BudgetTracker.Application.Helpers.LocalSecretHelper;

public class LocalSecretsHelper
{
    public static async Task<string> GetSecretAsync(Secret secret)
    {
        return await SecretsHelper.GetSecretAsync(secret);
    }

    public static async Task<string> GetSecretAsync(LocalSecret secret)
    {
        return await SecretsHelper.GetSecretAsync(secret.ToString());
    }

    public static string GetSecretSync(Secret secret, bool useMongo = false)
    {
        return SecretsHelper.GetSecretSync(secret, useMongo);
    }

    public static string GetSecretSync(LocalSecret secret, bool useMongo = false)
    {
        return SecretsHelper.GetSecretSync(secret.ToString(), useMongo);
    }
}
