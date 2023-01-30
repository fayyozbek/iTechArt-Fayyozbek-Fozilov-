namespace WorkWithComponentsSelenium.Pages;

public class NewWindowPage : BasePage
{
    public NewWindowPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => HerokuAppXpath.XPathQueryGenerator("class" ,"example", "h3");
    
    protected override string UrlPath { get; }
    
    public new bool IsPageOpened => WebDriver.FindElement(UniqueWebLocator).Text.Contains("Window");
}