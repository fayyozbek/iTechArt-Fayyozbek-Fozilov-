namespace Patterns.Core.BrowserConfiguration;

public abstract class BrowserFactory
{
    protected BrowserFactory()
    {
    }

    public IBrowser GetBrowser => new Browser(WebDriver);
    
    protected abstract WebDriver WebDriver { get; }
}