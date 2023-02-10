using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumWebDriverBasics.Locators;

namespace SeleniumWebDriverBasics.Pages;

public class HomePage : BasePage
{
    public HomePage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => OnlinerXPath.XPathQueryGenerator("project-navigation__part_1");
    
    protected override string UrlPath => string.Empty;

    private readonly By _mobilePhoneLinkLocator = OnlinerXPath.XPathQueryGenerator("href", "mobile");

    private IWebElement MobilePhoneLink => WebDriver.FindElement(_mobilePhoneLinkLocator);

    private readonly By _authButtonLocator = OnlinerXPath.XPathQueryGenerator("item auth-bar__item--text");

    private IWebElement AuthButton => WebDriver.FindElement(_authButtonLocator);
    
    public void ClickMobilePhoneLink()
    {
        Logger.Instance.Info($"CLick on link {MobilePhoneLink}");
        MobilePhoneLink.Click();
    }

    [AllureStep("CLick on the  authentication")]
    public void ClickAuth()
    {
        Logger.Instance.Info($"Click auth{AuthButton}");
        AuthButton.Click();
    }
}