using Microsoft.Extensions.Configuration;

namespace Core.Backend;

public static partial class ConfigurationExtensions
{
    public static string? GetConnectionStringThatAlsoWorksInProduction(this IConfiguration configuration, string name, bool isDevelopment = false)
    {
        Console.WriteLine(configuration.GetConnectionString(isDevelopment ? name : "Production")?.Replace("core", name.ToLower()) ?? "oida na bitte");
        return configuration.GetConnectionString(isDevelopment ? name : "Production")?.Replace("core", name.ToLower()) ?? null;
    }
}
