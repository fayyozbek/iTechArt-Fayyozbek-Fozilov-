using AngleSharp.Common;
using Microsoft.VisualBasic.FileIO;
using WorkWithComponentsSelenium.Configurations;

namespace WorkWithComponentsSelenium.Pages;

public class DownloadPage : BasePage
{
    public DownloadPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    private string NameOfFile { get;  set; }

    protected override By UniqueWebLocator => HerokuAppXpath.XPathQueryGenerator("class" ,"example", "h3");
    
    protected override string UrlPath => "/download";
    
    private new IWebElement UniqueWebElement => WebDriver.FindElement(UniqueWebLocator);
    
    public string PageOpenedText => UniqueWebElement.Text;

    private readonly By _linkToDownloadLocator = HerokuAppXpath.XPathQueryGenerator("href", "download");

    private IReadOnlyCollection<IWebElement> LinksToDownload => WebDriver.FindElements(_linkToDownloadLocator);

    public void DownloadFile()
    {
        var random = new Random();
        var linkToDownload =LinksToDownload.GetItemByIndex(  random.Next(0, LinksToDownload.Count - 1));
        NameOfFile = linkToDownload.Text;
        linkToDownload.Click();
    }

    public bool IsFileExists
    {
        get
        {
            var filePath = Path.Combine(AppConfiguration.PathToDefaultDirectory, NameOfFile);
            WebDriverWait.Until(_ => FileSystem.FileExists(filePath));
            return FileSystem.FileExists(filePath);
        }
    }
}