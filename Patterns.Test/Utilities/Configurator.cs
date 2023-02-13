using Microsoft.Extensions.Configuration;

namespace Patterns.Test.Utilities;

public class Configurator
{
    public static IConfiguration GetConfiguration()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Resources", "appsettings.json");
        var builder = new ConfigurationBuilder().AddJsonFile(path);
        var config = builder.Build();
        return config;
    }
}