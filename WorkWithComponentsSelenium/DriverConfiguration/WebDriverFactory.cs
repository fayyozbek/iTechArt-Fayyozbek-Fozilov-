using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WorkWithComponentsSelenium.Configurations;

namespace WorkWithComponentsSelenium.DriverConfiguration;

public class WebDriverFactory
{
    public IWebDriver GetDriver()
    {
        IWebDriver driver;

        var browser = AppConfiguration.Browser;

        switch (browser)
        {
            case Browser.Chrome:
               driver = new ChromeDriver(AppConfiguration.Settings);
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