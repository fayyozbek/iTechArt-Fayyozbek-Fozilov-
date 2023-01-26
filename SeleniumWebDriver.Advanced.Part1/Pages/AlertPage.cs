namespace SeleniumWebDriver.Advanced.Part1.Pages;

public class AlertPage : BasePage
{
    public AlertPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    private readonly string _randomText = GenerateRandomText();
    
    protected override By UniqueWebLocator => DemoqaXPath.XPathQueryGenerator("main-header");
    
    protected override string UrlPath => string.Empty;

    new public  bool IsPageOpened => WebDriver.FindElement(UniqueWebLocator).Text.Equals("Alerts");

    private readonly By _alertBtnLocator = DemoqaXPath.XPathQueryGenerator("id", "alertButton");
    
    private readonly By _confirmBtnLocator = DemoqaXPath.XPathQueryGenerator("id", "confirmButton");
    
    private readonly By _confirmResultLocator = DemoqaXPath.XPathQueryGenerator("id", "confirmResult");
    
    private readonly By _promptBtnLocator = DemoqaXPath.XPathQueryGenerator("id", "promtButton");
    
    private readonly By _promptResultLocator = DemoqaXPath.XPathQueryGenerator("id", "promptResult");

    private IWebElement AlertBtn => WebDriver.FindElement(_alertBtnLocator);
    
    private IWebElement ConfirmBtn => WebDriver.FindElement(_confirmBtnLocator);
    
    private IWebElement ConfirmResult => WebDriver.FindElement(_confirmResultLocator);
    
    private IWebElement PromptBtn => WebDriver.FindElement(_promptBtnLocator);
    
    private IWebElement PromptResult => WebDriver.FindElement(_promptResultLocator);

    public bool IsAlertOpened
    {
        get
        {
            WebDriverWait.Until(webDriver => webDriver.SwitchTo().Alert());
            return  WebDriver.SwitchTo().Alert().Text.Contains("You clicked a button");
        }
    }

    public bool IsConfirmAlertOpened =>{
        get
        {
            return WebDriver.SwitchTo().Alert().Text.Contains("Do you confirm action?");
        }
    }
    
    public bool IsPromptAlertOpened => WebDriver.SwitchTo().Alert().Text.Contains("Please enter your name");

    public bool IsAlertClosed
    {
        get
        {
            try
            {
                WebDriver.SwitchTo().Alert();
                return false;
            }
            catch (NoAlertPresentException)
            {
                return true;
            }  
        }
    }

    private static string GenerateRandomText()
    {
        var random = new Random();
        var length = 5;
        return new string(Enumerable.Repeat(Chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public bool IsAfterConfirmAlertClosedTextAvailable => ConfirmResult.Text.Contains("Ok");
    
    public bool IsAfterPromptAlertClosedTextAvailable => PromptResult.Text.Contains(_randomText);

    public void ClickAlertBtn()
    {
        AlertBtn.Click();
    }

    public void AcceptAlert()
    {
        WebDriverWait.Until(webDriver => webDriver.SwitchTo().Alert());
        WebDriver.SwitchTo().Alert().Accept();
    }

    public void ClickConfirmBtn()
    {
        ConfirmBtn.Click();
    }

    public void ClickPromptBtn()
    {
        PromptBtn.Click();
    }

    public void SendRandomlyGeneratedText()
    {
        WebDriver.SwitchTo().Alert().SendKeys(_randomText);
    }
}