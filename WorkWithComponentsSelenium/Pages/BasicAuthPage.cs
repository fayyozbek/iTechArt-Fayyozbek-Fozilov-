namespace WorkWithComponentsSelenium.Pages;

public class BasicAuthPage : BasePage
{
    public BasicAuthPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => By.TagName("body");

    protected override string UrlPath => "/basic_auth";

    public string PageOpenedText => WebDriver.Url;

    public string AuthenticationPassedText => WebDriver.Title;
    
    private readonly By expectedTextParagraphLocator = HerokuAppXpath.XPathQueryGenerator("class", "example", "p");

    private IWebElement ExpectedTextParagraph => WebDriver.FindElement(expectedTextParagraphLocator);

    public string ExpectedText => ExpectedTextParagraph.Text;

    public void EnterUsernameAndPassword(string username, string password)
    {
        WebDriver.Navigate().GoToUrl($"http://{username}:{password}@the-internet.herokuapp.com/basic_auth");
    }
}