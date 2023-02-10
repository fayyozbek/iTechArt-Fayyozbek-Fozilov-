using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Lection.SimpleWrapper.Core;
using SeleniumWrapper.Core.BrowserConfiguration;
using SeleniumWrapper.Core.Elements;
using SeleniumWrapper.Core.Utilities;

namespace SeleniumWrapper.Core.Forms;

public abstract class BaseForm
{
    protected BaseForm(Browser browser)
    {
    }

    protected abstract By UniqueWebLocator { get; }


    protected BaseElement UniqueElement =>new Label(UniqueWebLocator, "Unique Element ") ;

    protected BaseForm(BaseElement uniqueElement, string nameOfPage)
    {
    }

    public bool IsPageOpened => UniqueElement.IsDisplayed();
    
    public void WaitForPageOpened()
    {
        try
        {
            BrowserService.Browser.BrowserWait.Until(driver => driver.FindElement(UniqueWebLocator).Displayed);
        }
        catch (WebDriverTimeoutException e)
        {
            var errorMessage = $"Page with unique locator: '{UniqueWebLocator}' was not opened";
            Logger.Instance.Fatal(errorMessage);
            throw new AssertionException(errorMessage, e);
        }
    }

    protected void ScrollToUp()
    {
        var js = $"window.scrollTo({0}, {0})";
        BrowserService.Browser.JavaScriptExecutor.ExecuteScript(js);
    }
}