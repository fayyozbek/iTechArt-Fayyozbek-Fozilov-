namespace WorkWithComponentsSelenium.Pages;

public class WindowsPage : BasePage
{
    public WindowsPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => HerokuAppXpath.XPathQueryGenerator("href", "windows");
    
    protected override string UrlPath => "/windows";

    private IWebElement LinkToNewWindow => WebDriver.FindElement(UniqueWebLocator);

    public void OpenNewWindow()
    {
        LinkToNewWindow.Click();
    }
}