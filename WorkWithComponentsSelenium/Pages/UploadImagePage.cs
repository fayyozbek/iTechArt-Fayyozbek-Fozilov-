using WorkWithComponentsSelenium.Configurations;

namespace WorkWithComponentsSelenium.Pages;

public class UploadImagePage : BasePage
{
    public UploadImagePage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => HerokuAppXpath.XPathQueryGenerator("id", "drag-drop-upload");
    
    protected override string UrlPath => "/upload";

    private string PathOfFolderWhere=>  AppConfiguration.PathToDefaultDirectory;

    private readonly By _uploadLocator = HerokuAppXpath.XPathQueryGenerator("id", "file-upload");
    
    private readonly By _uploadBtnLocator = HerokuAppXpath.XPathQueryGenerator("id", "file-submit");
    
    private readonly By _expectedTextLocator = HerokuAppXpath.XPathQueryGenerator("class", "example", "h3");
    
    private readonly By _uploadedFilesLocator = HerokuAppXpath.XPathQueryGenerator("id", "uploaded-files");

    private IWebElement UploadBtn => WebDriver.FindElement(_uploadBtnLocator);
    
    private IWebElement Upload => WebDriver.FindElement(_uploadLocator);
    
    private IWebElement UploadedFiles => WebDriver.FindElement(_uploadedFilesLocator);
    
    private IWebElement ExpectedText => WebDriver.FindElement(_expectedTextLocator);

    public void LoadImage(string nameOfFile)
    {
        Upload.SendKeys(PathOfFolderWhere+nameOfFile);
        UploadBtn.Click();
    }

    public string GetExpectedText()
    {
        return ExpectedText.Text;
    }

    public string UploadedFilesText => UploadedFiles.Text;
}