using NUnit.Framework;
using Patterns.Core.BrowserConfiguration;
using Patterns.Core.Elements;

namespace Patterns.Core.Forms;

public abstract class BaseForm
{
    protected IElementsBuilder Builder => new ElementsBuilder();
    protected Browser Browser { get; }

    protected BaseForm(Browser browser)
    {
        Browser = browser;
    }

    protected abstract By UniqueWebLocator { get; }


    protected IElement UniqueElement =>Builder.CreateLabel(UniqueWebLocator, "Unique Element"); 

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
        BrowserService.Browser.JavaScriptExecutor.ExecuteScript(js);
    }
}