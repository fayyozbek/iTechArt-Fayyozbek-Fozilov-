using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WorkWithComponentsSelenium.Configurations;

namespace WorkWithComponentsSelenium.Pages;

public abstract class BasePage
{
    protected IWebDriver WebDriver { get;  }
    
    protected WebDriverWait WebDriverWait { get; }

    protected IJavaScriptExecutor JavaScriptExecutor { get; }
    
    protected Actions ActionBuilder { get; }

    protected BasePage(IWebDriver webDriver)
    {
        WebDriver = webDriver;
        WebDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(AppConfiguration.ConditionTimeout));
        JavaScriptExecutor = (IJavaScriptExecutor)WebDriver;
        ActionBuilder = new Actions(WebDriver);
    }
    
    protected IWebElement UniqueWebElement => WebDriver.FindElement(UniqueWebLocator);
    
    protected abstract By UniqueWebLocator { get; }

    private readonly string _baseUrl = AppConfiguration.BaseUrl;
    
    protected abstract string UrlPath { get; }

    public static string ExpectedUrl;

    public void OpenPage()  
    {
        var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        WebDriver.Navigate().GoToUrl(uri);
        WaitForPageLoad();
    }
    
    public bool IsPageOpened => UniqueWebElement.Displayed;

    public void MoveToLastOrDefaultTab()
    {
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles.LastOrDefault());
    }

    public void MoveToTab(int tabNumber)
    {
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles[tabNumber]);
    }
    
    private void WaitForPageLoad()
    {
        try
        {
            WebDriverWait.Until(driver => driver.FindElement(UniqueWebLocator).Displayed);
        }
        catch (WebDriverTimeoutException e)
        {
            throw new AssertionException($"Page with unique locator: '{UniqueWebLocator}' was not opened", e);
        }
    }

    public bool IsTabClosed(int tabNumber)
    {
        try
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles[tabNumber]);
            return false;
        }
        catch (Exception )
        {
            return true;
        }
    }

    public void BackToPreviousPage()
    {
        WebDriver.Navigate().Back();
    }
    
    public bool IsTabClosed()
    {
        try
        {
            return IsPageOpened;
        }
        catch (Exception)
        {
            return true;
        }
    }
    
    public void CloseTab()
    {
        WebDriver.Close();
    }

    public string GetUrl => WebDriver.Url;
}