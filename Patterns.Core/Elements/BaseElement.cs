namespace Patterns.Core.Elements;

public abstract class BaseElement
{
    protected By Locator { get; }

    protected string Name { get; }

    protected BaseElement(By locator, string name)
    {
        Locator = locator;
        Name = name;
    }

    private WebDriver WebDriver => BrowserService.Browser.WebDriver;

    public void Click()
    {
        Logger.Instance.Info($"Click {Name} element");
        FindElement().Click();
    }

    public string GetText()
    {
        Logger.Instance.Info($"Take text from {Name} element");
        Logger.Instance.Info(FindElement().Text);
        return FindElement().Text;
    }

    public bool IsDisplayed()
    {
        return FindElement().Displayed;
    }

    protected IWebElement FindElement()
    {
        Logger.Instance.Info($"Find element with locator {Locator}");
        return WebDriver.FindElement(Locator);
    }
    
    public void ScrollToView()
    {
        var element = FindElement();
        if (element.Location.Y > 200)
        {
            var js = $"window.scrollTo({0}, {element.Location.Y-150})";
            BrowserService.Browser.JavaScriptExecutor.ExecuteScript(js);
        }
    }
}