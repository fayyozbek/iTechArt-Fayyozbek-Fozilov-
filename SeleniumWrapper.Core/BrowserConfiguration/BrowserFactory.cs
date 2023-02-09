using OpenQA.Selenium;

namespace SeleniumWrapper.Core.BrowserConfiguration;

public abstract class BrowserFactory
{
    protected BrowserFactory()
    {
        
    }

    public Browser GetBrowser => new Browser(WebDriver);
    
    protected abstract WebDriver WebDriver { get; }
}