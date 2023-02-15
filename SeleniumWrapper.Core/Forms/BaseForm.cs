using NUnit.Framework;

namespace SeleniumWrapper.Core.Forms;

public abstract class BaseForm
{
    protected Browser Browser { get; private set; }

    protected BaseForm(Browser browser)
    {
        Browser = browser;
    }

    protected abstract By UniqueWebLocator { get; }


    protected BaseElement UniqueElement =>new Label(UniqueWebLocator, "Unique Element ") ;

    public bool IsPageOpened => UniqueElement.IsDisplayed();
    
    public void WaitForPageOpened()
    {
        try
        {
            Browser.BrowserWait.Until(driver => driver.FindElement(UniqueWebLocator).Displayed);
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
        Browser.JavaScriptExecutor.ExecuteScript(js);
    }
}