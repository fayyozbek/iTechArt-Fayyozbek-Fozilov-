using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumWebDriverBasics.Configurations;
using SeleniumWebDriverBasics.Utilities;

namespace SeleniumWebDriverBasics.DriverConfiguration;

public class WebDriverFactory
{
    public IWebDriver GetDriver()
    {
        IWebDriver driver;

        var browser = AppConfigurator.Browser;
        Logger.Instance.Debug($"Start browser '{browser}'");

        switch (browser)
        {
            case Browser.Chrome:
               driver = new ChromeDriver(AppConfigurator.Settings);
               Logger.Instance.Debug(((WebDriver)driver).AuthenticatorId);
                return driver;
            case Browser.Edge:
                driver = new EdgeDriver();
                return driver;
            case Browser.FireFox:
                driver = new FirefoxDriver();
                return driver;
            default: throw new ArgumentException($"Browser '{browser}' is not supported yet");
        }
    }
}

public enum Browser
{
    Chrome,
    Edge,
    FireFox
}