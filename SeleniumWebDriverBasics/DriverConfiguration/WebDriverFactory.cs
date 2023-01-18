using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumWebDriverBasics.Utilities;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumWebDriverBasics.DriverConfiguration;

public class WebDriverFactory
{
    public IWebDriver GetDriver()
    {
        IWebDriver driver;

        var browser = Configurator.Browser;

        switch (browser)
        {
            case Browser.Chrome:
                //new DriverManager().SetUpDriver(new ChromeConfig());
                var options = new ChromeOptions();
                options.AddArguments(ChromeArguments());
                driver = new ChromeDriver(options);
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

    private IEnumerable<string> ChromeArguments()
    {
        yield return "no-sandbox";
        yield return "--disable-dev-shm-usage";
        yield return "--disable-gpu";
     //   yield return "headless";
        yield return "window-size=1920,1080";
        yield return "--disable-extensions";
    }
}

public enum Browser
{
    Chrome,
    Edge,
    FireFox
}