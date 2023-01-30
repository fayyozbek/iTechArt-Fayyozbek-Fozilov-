using SeleniumExtras.WaitHelpers;

namespace SeleniumWebDriver.Advanced.Part1.Pages;

public class BrowserWindowsPage : BasePage
{
    public BrowserWindowsPage(IWebDriver webDriver) : base(webDriver)
    {
    }
    
    protected override By UniqueWebLocator  => DemoqaXPath.XPathQueryGenerator("main-header");
    
    protected override string UrlPath { get; }
    
    new public  bool IsPageOpened => WebDriver.FindElement(UniqueWebLocator).Text.Equals("Browser Windows");

    private readonly By _elementsBtnLocator = DemoqaXPath.ElementBtnLocator;

    private IWebElement ElementsBtn => WebDriver.FindElement(_elementsBtnLocator);
    
    private readonly By _linksBtnLocator = DemoqaXPath.XPathQueryGenerator("id", "item-5", "span[contains(text(),\"Links\")]");

    private IWebElement LinksBtn => WebDriver.FindElement(_linksBtnLocator);

    public void ClickTabBtn()
    {
        var js = "document.getElementById(\"tabButton\").click()";
        JavaScriptExecutor.ExecuteScript(js);   
    }

    public void ClickLinksBtn()
    {
        ElementsBtn.Click();
        ScrollToView(LinksBtn);
        LinksBtn.Click();
    }
}