using Microsoft.VisualBasic.FileIO;
using WorkWithComponentsSelenium.Configurations;

namespace WorkWithComponentsSelenium.Pages;

public class DownloadPage : BasePage
{
    public DownloadPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => HerokuAppXpath.XPathQueryGenerator("class" ,"example", "h3");
    
    protected override string UrlPath => "/download";
    
    public new bool IsPageOpened => WebDriver.FindElement(UniqueWebLocator).Text.Contains("File Downloader");

    private readonly By _linkToDownloadLocator = HerokuAppXpath.XPathQueryGenerator("href", "my-screenshot");

    private IWebElement LinkToDownload => WebDriver.FindElement(_linkToDownloadLocator);

    public void DownloadFile()
    {
        LinkToDownload.Click();
    }

    public bool IsFileExists
    {
        get
        {
            var filePath = Path.Combine(AppConfiguration.PathToDefaultDirectory, "my-screenshot.png");
            WebDriverWait.Until(_ => FileSystem.FileExists(filePath));
            return FileSystem.FileExists(filePath);
        }
    }
}