using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.Advanced.Part1.Configurations;

namespace SeleniumWebDriver.Advanced.Part1.Pages;

public abstract class BasePage
{
    protected IWebDriver WebDriver { get;  }
    
    protected WebDriverWait WebDriverWait { get; }

    protected IJavaScriptExecutor JavaScriptExecutor { get; }
    
    protected BasePage(IWebDriver webDriver)
    {
        WebDriver = webDriver;
        WebDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(AppConfigurator.ConditionTimeout));
        JavaScriptExecutor = (IJavaScriptExecutor)WebDriver;
    }
    
    protected IWebElement UniqueWebElement => WebDriver.FindElement(UniqueWebLocator);
    
    protected abstract By UniqueWebLocator { get; }

    private readonly string _baseUrl = AppConfigurator.BaseUrl;
    
    protected abstract string UrlPath { get; }

    public void OpenPage()  
    {
        var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        WebDriver.Navigate().GoToUrl(uri);
        WaitForPageLoad();
    }
    
    public bool IsPageOpened
    {
        get
        {
            bool isOpened;
            try
            {
                isOpened = UniqueWebElement.Displayed;
            }
            catch (Exception e)
            {
                isOpened = false;
            }
            return isOpened;
        }
    }

    public void BackPage()
    {
        WebDriver.Navigate().Back();
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
    
    protected void ScrollToView(IWebElement element)
    {
        if (element.Location.Y > 200)
        {
            var js = $"window.scrollTo({0}, {element.Location.Y-80})";
            JavaScriptExecutor.ExecuteScript(js);
        }
    }
}