namespace WorkWithComponentsSelenium.Pages;

public class BasicAuthPage : BasePage
{
    public BasicAuthPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => By.TagName("body");

    protected override string UrlPath => "/basic_auth";

    public new bool IsPageOpened => WebDriver.Url.Contains("basic_auth");

    public bool IsAuthenticationPassed => WebDriver.Title.Contains("Internet");
    
    private readonly string _expectedText="Congratulations! You must have the proper credentials.";

    private readonly By expectedTextParagraphLocator = HerokuAppXpath.XPathQueryGenerator("class", "example", "p");

    private IWebElement ExpectedTextParagraph => WebDriver.FindElement(expectedTextParagraphLocator);

    public bool IsExpectedTextAvailable => ExpectedTextParagraph.Text.Equals(_expectedText);

    public void EnterUsernameAndPassword(string username, string password)
    {
        WebDriver.Navigate().GoToUrl($"http://{username}:{password}@the-internet.herokuapp.com/basic_auth");
    }
}