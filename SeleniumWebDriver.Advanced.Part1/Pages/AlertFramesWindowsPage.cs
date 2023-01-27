using SeleniumWebDriver.Advanced.Part1.Pages;

namespace SeleniumWebDriver.Advanced.Part1;

public class AlertFramesWindowsPage : BasePage
{
    public AlertFramesWindowsPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator { get; }
    
    protected override string UrlPath { get; }
    
    private readonly By _alertsBtnLocator = DemoqaXPath.XPathQueryGenerator("id", "item-1", "span[text()=\"Alerts\"]");

    private readonly By _nestedFrameBtnLocator = DemoqaXPath.XPathQueryGenerator("id", "item-3", "span[contains(text(),\"Frame\")]");
    
    private readonly By _browserWindowsBtnLocator = DemoqaXPath.XPathQueryGenerator("id", "item-0", "span[contains(text(),\"Browser\")]");

    private IWebElement AlertsBtn => WebDriver.FindElement(_alertsBtnLocator);
    
    private IWebElement NestedFramesBtn => WebDriver.FindElement(_nestedFrameBtnLocator);
    
    private IWebElement BrowserWindowsFramesBtn => WebDriver.FindElement(_browserWindowsBtnLocator);

    public void ClickAlertsBtn()
    {
        ScrollToView(AlertsBtn);
        AlertsBtn.Click();
    }

    public void ClickNestedFramesBtn()
    {
        ScrollToView(NestedFramesBtn);
        NestedFramesBtn.Click();
    }

    public void ClickBrowserWindowsFramesBtn()
    {
        BrowserWindowsFramesBtn.Click();
    }
}