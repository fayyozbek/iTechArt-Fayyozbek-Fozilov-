namespace Patterns.Core.BrowserConfiguration;

public abstract class BrowserFactory
{
    protected BrowserFactory()
    {
    }

    public Browser GetBrowser => new(WebDriver);
    
    protected abstract WebDriver WebDriver { get; }
}