namespace SeleniumWebDriver.Advanced.Part1.Pages;

public class HomePage : BasePage
{
    public HomePage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => DemoqaXPath.XPathQueryGenerator("home-banner");
    
    protected override string UrlPath => string.Empty;

    private readonly By _alertFrameWindowsBtnLocator = DemoqaXPath.XPathQueryGenerator("d", "3h1v1H5V3zM3" ,"parent::*");
    
    private readonly By _widgetsBtnLocator = DemoqaXPath.XPathQueryGenerator("d", "13v8h8v-8h-8zM3 21h8v-8H3v8zM3" ,"parent::*");

    private IWebElement WidgetsBtn => WebDriver.FindElement(_widgetsBtnLocator);

    private IWebElement AlertFrameWindowsBtn => WebDriver.FindElement(_alertFrameWindowsBtnLocator);
    
    public void ClickAlertFrameWindowBtn()
    {
        ScrollToView(AlertFrameWindowsBtn);
        AlertFrameWindowsBtn.Click();
    }

    public void ClickWidgetBtn()
    {
        ScrollToView(WidgetsBtn);
        WidgetsBtn.Click();
    }
}