using OpenQA.Selenium.Chrome;
using WorkWithComponentsSelenium.DriverConfiguration;
using WorkWithComponentsSelenium.Utilities;

namespace WorkWithComponentsSelenium.Configurations;

public class AppConfiguration
{
    private const string UrlKey= "url";
    
    private const string BrowserKey= "browser";
    
    private const string StartArgumentKey= "startArguments";
    
    private const string ConditionTimeoutKey = "conditionTimeout";

    public static readonly string PathToDefaultDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/");

    public static readonly int ConditionTimeout = Convert.ToInt32(Configurator.GetConfiguration().GetSection(ConditionTimeoutKey).Value);

    public static readonly string BaseUrl=  Configurator.GetConfiguration().GetSection(UrlKey).Value;
    
    public static readonly Browser Browser =Enum.Parse<Browser>(Configurator.GetConfiguration().GetSection(BrowserKey).Value, true);
    
    public static readonly ChromeOptions Settings = GetSettings();

    private static ChromeOptions GetSettings()
    {
        string[] options = Configurator.GetConfiguration().GetSection(StartArgumentKey).Get<string[]>();
        var settings = new ChromeOptions();
        settings.AddArguments(options);
        settings.AddUserProfilePreference("download.default_directory", PathToDefaultDirectory );
        return settings;
    }
}