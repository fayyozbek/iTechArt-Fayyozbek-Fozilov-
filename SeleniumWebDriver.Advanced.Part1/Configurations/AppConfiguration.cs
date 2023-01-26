using OpenQA.Selenium.Chrome;
using SeleniumWebDriver.Advanced.Part1.DriverConfiguration;
using SeleniumWebDriver.Advanced.Part1.Utilities;

namespace SeleniumWebDriver.Advanced.Part1.Configurations;

public class AppConfigurator
{
    private const string UrlKey= "url";
    
    private const string BrowserKey= "browser";
    
    private const string StartArgumentKey= "startArguments";
    
    private const string ConditionTimeoutKey = "conditionTimeout";
    
    public static readonly int ConditionTimeout = Convert.ToInt32(Configurator.GetConfiguration().GetSection(ConditionTimeoutKey).Value);

    public static readonly string BaseUrl=  Configurator.GetConfiguration().GetSection(UrlKey).Value;
    
    public static readonly Browser Browser =Enum.Parse<Browser>(Configurator.GetConfiguration().GetSection(BrowserKey).Value, true);
    
    public static readonly ChromeOptions Settings = GetSettings();

    private static ChromeOptions GetSettings()
    {
        string[] options = Configurator.GetConfiguration().GetSection(StartArgumentKey).Get<string[]>();
        var settings = new ChromeOptions();
        settings.AddArguments(options);
        return settings;
    }
}