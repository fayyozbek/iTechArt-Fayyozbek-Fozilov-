using System.ComponentModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWrapper.Core.Utilities;

namespace SeleniumWrapper.Core.BrowserConfiguration;

public class LocalBrowserFactory : BrowserFactory
{
    private BrowserModel BrowserModel { get; }

    public LocalBrowserFactory(BrowserModel browserModel) : base()
    {
        BrowserModel = browserModel;
    }

    protected override WebDriver WebDriver
    {
        get
        {
            var browserName = BrowserModel.BrowserName;
            var driverSettingsStrings = BrowserModel.BrowserSettings;
            var driverSettings = new ChromeOptions();
            driverSettings.AddArguments(driverSettingsStrings);

            WebDriver webDriver;

            switch (browserName)
            {
                case BrowserEnum.Chrome:
                    var options = driverSettings;
                    //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    Logger.Instance.Debug("Open Chrome window");
                    webDriver = new ChromeDriver(options);
                    return webDriver;
                default:
                    throw new InvalidEnumArgumentException($"WebDriver for browser {browserName} is not supported");
            }
        }
    }
}
public enum BrowserEnum
{
    Chrome,
    Opera
}