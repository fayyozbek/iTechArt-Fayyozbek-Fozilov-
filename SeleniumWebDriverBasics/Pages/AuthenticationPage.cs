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

    private readonly By _usernameInputLocator = OnlinerXPath.XPathQueryGenerator("type","text");
    
    private readonly By _passwordInputLocator = OnlinerXPath.XPathQueryGenerator("type", "password");
    
    private readonly By _recaptchaAnchorLocator = OnlinerXPath.XPathQueryGenerator("id", "recaptcha-anchor");

    private IWebElement UsernameInput => WebDriver.FindElement(_usernameInputLocator);

    private IWebElement PasswordInput => WebDriver.FindElement(_passwordInputLocator);

    [AllureStep("Input username as {0} and passsword as {1}")]
    public void InputUsernameAndPassword(string username, string password)
    {
        Logger.Instance.Info($"Input username {username} in {UsernameInput}");
        UsernameInput.SendKeys(username);
        Logger.Instance.Info($"Input password {password} in {PasswordInput}");
        PasswordInput.SendKeys(password);
        PasswordInput.Submit();
    }

    public void CLickOnIamNotRobot()
    {
        
    }
}