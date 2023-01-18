using SeleniumWebDriverBasics.DriverConfiguration;

namespace SeleniumWebDriverBasics.Utilities;

public class Configurator
{
    public static readonly Browser Browser = Enum.Parse<Browser>("chrome", true);
    public static readonly string BaseUrl = "https://www.onliner.by/";
}