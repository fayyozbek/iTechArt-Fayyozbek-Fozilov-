namespace SeleniumWebDriver.Advanced.Part1.Pages;

public class LinksPage : BasePage
{
    public LinksPage(IWebDriver webDriver) : base(webDriver)
    {
    }
    
    protected override By UniqueWebLocator  => DemoqaXPath.XPathQueryGenerator("main-header");
    
    protected override string UrlPath { get; }
    
    new public  bool IsPageOpened => WebDriver.FindElement(UniqueWebLocator).Text.Equals("Links");
    
    public void ClickHomeLink()
    {
        var js = "document.getElementById(\"simpleLink\").click()";
        JavaScriptExecutor.ExecuteScript(js);
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
    }
}