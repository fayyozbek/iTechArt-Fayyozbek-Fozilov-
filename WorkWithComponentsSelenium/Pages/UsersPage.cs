namespace WorkWithComponentsSelenium.Pages;

public class UsersPage : BasePage
{
    public UsersPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator { get; }
    
    protected override string UrlPath { get; }

    public bool IsExpectedUrlEqualToCurrentUrl => ExpectedUrl.Contains( WebDriver.Url);
    
}