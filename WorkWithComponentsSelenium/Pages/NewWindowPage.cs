namespace WorkWithComponentsSelenium.Pages;

public class NewWindowPage : BasePage
{
    public NewWindowPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => HerokuAppXpath.XPathQueryGenerator("class" ,"example", "h3");
    
    protected override string UrlPath { get; }

    private new IWebElement UniqueWebElement => WebDriver.FindElement(UniqueWebLocator);
    
    public  string UniqueWebElementText => UniqueWebElement.Text;
}