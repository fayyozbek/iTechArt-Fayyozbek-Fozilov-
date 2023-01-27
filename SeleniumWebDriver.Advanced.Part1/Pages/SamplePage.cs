namespace SeleniumWebDriver.Advanced.Part1.Pages;

public class SamplePage : BasePage
{
    public SamplePage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => DemoqaXPath.XPathQueryGenerator("id", "sampleHeading");
    protected override string UrlPath { get; }

    new public bool IsPageOpened
    {
        get
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
            return WebDriver.FindElement(UniqueWebLocator).Displayed;
        }
    }
}