using System.ComponentModel;
using OpenQA.Selenium.Chrome;
using PracticeExam.Core.Utilities;

namespace PracticeExam.Core.BrowserConfiguration;

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
                    Logger.Instance.Debug("initializes Chrome window");
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