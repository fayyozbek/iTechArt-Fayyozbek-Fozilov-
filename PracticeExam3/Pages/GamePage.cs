using OpenQA.Selenium;
using PracticeExam3.Locators;
using PracticeExam3.Utilities;
using SeleniumWebDriver.Advanced.Part1.Utilities;

namespace PracticeExam3.Pages;

public class GamePage : BasePage
{
    public GamePage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => UserinyerfaceXPath.XPathQueryGenerator("login-form__container");
    
    protected override string UrlPath => "/game.html";

    private readonly By _passwordInputLocator = UserinyerfaceXPath.XPathQueryGenerator("placeholder", "Password");

    private readonly By _emailInputLocator = UserinyerfaceXPath.XPathQueryGenerator("placeholder", "email");

    private readonly By _domainInputLocator = UserinyerfaceXPath.XPathQueryGenerator("placeholder", "Domain");

    private readonly By _dropDownItemLocator = By.XPath("//*[contains(@class,\"dropdown__list-item\" ) and not(contains(@class,\"selected\" ))]");
    
    private readonly By _nextBtnLocator = By.XPath("//*[contains(@class,\"button--secondary\" ) and not(contains(@class,\"u-right\" ))]");

    private readonly By _dropDownIconLocator = UserinyerfaceXPath.XPathQueryGenerator("icon-chevron-down");
    
    private readonly By _checkIconLocator = UserinyerfaceXPath.XPathQueryGenerator("icon-check");

    private readonly By _pageIndicatorLocator = UserinyerfaceXPath.XPathQueryGenerator("page-indicator");
    
    private readonly By _acceptButtonLocator = UserinyerfaceXPath.XPathQueryGenerator("button--transparent");
    
    private readonly By _CoockieLabelLocator = UserinyerfaceXPath.XPathQueryGenerator("cookie");

    private readonly By _timerLabelLocator = UserinyerfaceXPath.XPathQueryGenerator("timer--center");
    
    private readonly By _helperSendToBottomBtnLocator = UserinyerfaceXPath.XPathQueryGenerator("help-form__send-to-bottom-button");
    
    private readonly By _helperFormLocator = UserinyerfaceXPath.XPathQueryGenerator("help-form");
    
    private IWebElement PasswordInput => WebDriver.FindElement(_passwordInputLocator);

    private IWebElement EmailInput => WebDriver.FindElement(_emailInputLocator);
    
    private IWebElement DomainInput => WebDriver.FindElement(_domainInputLocator);

    private IWebElement DropDownItem => WebDriver.FindElement(_dropDownItemLocator);
    
    private IWebElement DropDownIcon => WebDriver.FindElement(_dropDownIconLocator);
    
    private IWebElement CheckIcon => WebDriver.FindElement(_checkIconLocator);

    private IWebElement AcceptBtn => WebDriver.FindElement(_acceptButtonLocator);

    private IWebElement NextBtn => WebDriver.FindElement(_nextBtnLocator);

    private IWebElement TimerLabel => WebDriver.FindElement(_timerLabelLocator);

    private IWebElement PageIndicator => WebDriver.FindElement(_pageIndicatorLocator);
    
    private IWebElement HelperSendToBottomBtn=> WebDriver.FindElement(_helperSendToBottomBtnLocator);
    
    private IWebElement HelperForm=> WebDriver.FindElement(_helperFormLocator);
    
    public void  SendRndKeysToInputs()
    {
        var rndStr = TextGenerator.GenerateRandomText();
        PasswordInput.Clear();
        PasswordInput.SendKeys(rndStr.ToUpper());
        Logger.Instance.Info($"Password is {rndStr.ToUpper()}");
        EmailInput.Clear();
        EmailInput.SendKeys(rndStr.ToLower());
        Logger.Instance.Info($"Email is {rndStr.ToLower()}");
        DomainInput.Clear();
        DomainInput.SendKeys("mail");
    }

    public void SelectDropdown()
    {
        DropDownIcon.Click();
        DropDownItem.Click();
        Logger.Instance.Info("Select first item from dropdown");
    }

    public void SelectCheckBox()
    {
        CheckIcon.Click();
        Logger.Instance.Info("Unselect checkbox");
    }

    public void ClickNextButton()
    {
        NextBtn.Click();
        Logger.Instance.Info("Click Next Button");
        WebDriverWait.Until(_ => GetPageIndicator.Contains("2"));
    }

    public void ClickAcceptCoockie()
    {
        WebDriverWait.Until(webDriver => webDriver.FindElement(_CoockieLabelLocator).Displayed);
        AcceptBtn.Click();
        Logger.Instance.Info("Accept Cookie");
    }
    
    public bool IsCookeLabel
    {
        get
        {
            try
            {
                return !WebDriver.FindElement(_CoockieLabelLocator).Displayed;
            }
            catch (NoSuchElementException)
            {
                Logger.Instance.Info("Cookie label is closed");
                return true;
            }  
        }
    }

    public void ClickSendToBottomBtn()
    {
        HelperSendToBottomBtn.Click();
        Logger.Instance.Info("Hide helper form");
    }

    public string GetClassOfHelper => HelperForm.GetAttribute("class");
    public string GetTime => TimerLabel.Text;
    public string GetPageIndicator => PageIndicator.Text;
}
