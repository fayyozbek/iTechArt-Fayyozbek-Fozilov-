namespace SeleniumWebDriver.Advanced.Part1.Pages;

public class WidgetsPage : BasePage
{
    public WidgetsPage(IWebDriver webDriver) : base(webDriver)
    {
    }
    
    protected override By UniqueWebLocator  => DemoqaXPath.XPathQueryGenerator("main-header");
    
    protected override string UrlPath { get; }
    
    new public  bool IsPageOpened => WebDriver.FindElement(UniqueWebLocator).Text.Equals("Widgets");
    
    private readonly By _progressBtnLocator = DemoqaXPath.XPathQueryGenerator("id", "item-4", "span[contains(text(),\"Progress Bar\")]");

    public IWebElement ProgressBtn => WebDriver.FindElement(_progressBtnLocator);

    public void ClickProgressBtn()
    {
        ProgressBtn.Click();
    }
}