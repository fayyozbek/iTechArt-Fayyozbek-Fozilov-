namespace Patterns.Core.Elements;

internal abstract class BaseElement : IElement
{
    By IElement.Locator { get;  set; }

    string IElement.Name { get; set; }

    protected BaseElement(By locator, string name)
    {
        ((IElement)this).Locator = locator;
        ((IElement)this).Name = name;
    }

    private WebDriver WebDriver => BrowserService.Browser.WebDriver;

    public void Click()
    {
        Logger.Instance.Info($"Click {((IElement)this).Name} element");
        FindElement().Click();
    }

    public string GetText()
    {
        Logger.Instance.Info($"Take text from {((IElement)this).Name} element");
        Logger.Instance.Info(FindElement().Text);
        return FindElement().Text;
    }
    

    public bool IsDisplayed()
    {
        return FindElement().Displayed;
    }

    protected IWebElement FindElement()
    {
        Logger.Instance.Info($"Find element with locator {((IElement)this).Locator}");
        return WebDriver.FindElement(((IElement)this).Locator);
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