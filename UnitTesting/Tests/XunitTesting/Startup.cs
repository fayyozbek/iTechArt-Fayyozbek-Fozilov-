using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace UnitTesting.Tests.XunitTesting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ICalculator, Calculator>();
        services.AddTransient<IMemory, Memory>();

    }

    public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor)
    {
        loggerFactory.AddProvider(new XunitTestOutputLoggerProvider(accessor, (s, level) => level >=
            LogLevel.Debug && level < LogLevel.None));
    }
}