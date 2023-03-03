using OpenQA.Selenium.Support.UI;

namespace SeleniumWrapper.Core.BrowserConfiguration;

public class Browser : IBrowser
{
    public WebDriverWait BrowserWait { get; }
    public WebDriver WebDriver { get; }
    
    public IJavaScriptExecutor JavaScriptExecutor { get; }

    public Browser(WebDriver webDriver)
    {
        Logger.Instance.Info("Initiate Browser ");
        WebDriver = webDriver;
        BrowserWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(BrowserService.BrowserModel.ConditionTimeWait));
        JavaScriptExecutor = (IJavaScriptExecutor)WebDriver;
        MaximizeWindow();
        SetImplicitTime();
    }

    public void GoToUrl(Uri uri)
    {
        GoToUrl(uri.ToString());
    }
    
    public void GoToUrl(string uri)
    {
        Logger.Instance.Info($"Go to url {uri}");
        WebDriver.Navigate().GoToUrl(uri);
    }

    public void Quit()
    {
        Logger.Instance.Info("Quit browser");
        WebDriver.Quit();
    }

    private void MaximizeWindow()
    {
        Logger.Instance.Info("Maximize Window");
        WebDriver.Manage().Window.Maximize();
    }
    
    private void SetImplicitTime()
    {
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }
    
    public void BackPage()
    {
        Logger.Instance.Info("Back to previous page"); 
        WebDriver.Navigate().Back();
    }

    public bool IsStarted => WebDriver.SessionId != null;
}