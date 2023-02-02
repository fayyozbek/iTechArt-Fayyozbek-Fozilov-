using WorkWithComponentsSelenium.DriverConfiguration;
using WorkWithComponentsSelenium.Pages;

namespace WorkWithComponentsSelenium;

public class BaseTest
{
    protected IWebDriver WebDriver { get; private set; }
    
    protected BasicAuthPage BasicAuthPage { get; private set; }
    
    protected UploadImagePage UploadImagePage { get; private set; }
    
    protected ActionsPage ActionsPage { get; private set; }
    
    protected WindowsPage WindowsPage { get; private set; }

    protected NewWindowPage NewWindowPage { get; private set; }
    
    protected HoversPage HoversPage { get; private set; }

    protected DownloadPage DownloadPage { get; private set; }

    protected UsersPage UsersPage { get; private set; }
    
    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        
        BasicAuthPage = new BasicAuthPage(WebDriver);
        UploadImagePage = new UploadImagePage(WebDriver);
        ActionsPage = new ActionsPage(WebDriver);
        WindowsPage = new WindowsPage(WebDriver);
        NewWindowPage = new NewWindowPage(WebDriver);
        HoversPage = new HoversPage(WebDriver);
        DownloadPage = new DownloadPage(WebDriver);
        UsersPage = new UsersPage(WebDriver);
    }
    
    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}