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
    
    public void ClickMobilePhoneLink()
    {
        MobilePhoneLink.Click();
    }
}