using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriverBasics.Locators;

namespace SeleniumWebDriverBasics.Pages;

public class AuthenticationPage: BasePage
{
    public AuthenticationPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => OnlinerXPath.XPathQueryGenerator("auth-input_primary");
    protected override string UrlPath { get; }

    private readonly By _usernameInputLocator = OnlinerXPath.XPathForUsernameInput;
    
    private readonly By _passwordInputLocator = OnlinerXPath.XPathForPasswordInput;
    
    private readonly By _submitButtonLocator = OnlinerXPath.XPathQueryGenerator("type", "password");
    
    private readonly By _recaptchaAnchorLocator = OnlinerXPath.XPathQueryGenerator("id", "recaptcha-anchor", "parent::*");

    private readonly By _incorrectLabelLocator =
        OnlinerXPath.XPathQueryGenerator("auth-form__description auth-form__description_error auth-form__description_base auth-form__description_extended-other");

    private IWebElement UsernameInput => WebDriver.FindElement(_usernameInputLocator);

    private IWebElement PasswordInput => WebDriver.FindElement(_passwordInputLocator);

    private IWebElement SubmitButton => WebDriver.FindElement(_submitButtonLocator);
    
    private IWebElement recaptchaAnchor => WebDriver.FindElement(_recaptchaAnchorLocator);

    private IWebElement IncorrectLabel => WebDriver.FindElement(_incorrectLabelLocator);

    [AllureStep("Input username as {0} and passsword as {1}")]
    public void InputUsernameAndPassword(string username, string password)
    {
        Logger.Instance.Info($"Input username {username} in {UsernameInput}");
        UsernameInput.SendKeys(username);
        Logger.Instance.Info($"Input password {password} in {PasswordInput}");
        PasswordInput.SendKeys(password);
        PasswordInput.Submit();
    }

    [AllureStep("Click on \"I am not robot\"")]
    public void CLickOnIamNotRobot()
    {
        WebDriverWait.Until(_ => recaptchaAnchor.Displayed);
        Logger.Instance.Info($"Click on \"I am not robot\" {recaptchaAnchor}");
        recaptchaAnchor.Click();
    }

    public bool IsAuthenticationPass
    {
        get
        {
            bool isPassed=false;
            try
            {
                WebDriverWait.Until(_ => IncorrectLabel.Displayed);
                if (IncorrectLabel.Displayed)
                {
                    Logger.Instance.Error("Incorrect username and password");
                    isPassed= false;
                }
            }
            catch (NoSuchElementException)
            {
                Logger.Instance.Info("Authentication passed");
                isPassed= true;
            }

            return isPassed;
        }
    }
}