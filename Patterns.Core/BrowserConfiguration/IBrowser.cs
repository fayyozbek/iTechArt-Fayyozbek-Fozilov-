using OpenQA.Selenium.Support.UI;

namespace Patterns.Core.BrowserConfiguration;

public interface IBrowser
{
    public WebDriverWait BrowserWait { get; }
    
    public IJavaScriptExecutor JavaScriptExecutor { get; }
    public WebDriver WebDriver { get; }
    public bool IsStarted { get; }
    public void GoToUrl(Uri uri);
    public void Quit();
}