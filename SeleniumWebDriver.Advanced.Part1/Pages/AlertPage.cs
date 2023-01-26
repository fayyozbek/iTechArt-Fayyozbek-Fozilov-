using OpenQA.Selenium;

namespace SeleniumWebDriver.Advanced.Part1.Pages;

public class AlertPage : BasePage
{
    public AlertPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    private string _randomText
    {
        get
        {
            Random random = new Random();
            int length = 0;
            return new string(Enumerable.Repeat(_chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
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

    public bool IsAlertOpened => WebDriver.SwitchTo().Alert().Text.Contains("You clicked a button");
    
    public bool IsConfirmAlertOpened => WebDriver.SwitchTo().Alert().Text.Contains("Do you confirm action?");
    
    public bool IsPromtAlertOpened => WebDriver.SwitchTo().Alert().Text.Contains("Please enter your name");

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

    public bool IsAfterConfirmAlertClosedTextAvailable => ConfirmResult.Text.Contains("Ok");
    
    public bool IsAfterPromptAlertClosedTextAvailable => ConfirmResult.Text.Contains(_randomText);

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