using OpenQA.Selenium;
using PracticeExam3.Locators;
using PracticeExam3.Utilities;

namespace PracticeExam3.Pages;

public class HomePage : BasePage
{
    public HomePage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => UserinyerfaceXPath.XPathQueryGenerator("logo__icon");
    protected override string UrlPath { get; }

    private readonly By _startLinkLocator = UserinyerfaceXPath.XPathQueryGenerator("start__link");

    private IWebElement StartLink => WebDriver.FindElement(_startLinkLocator);

    public void ClickOnStartLink()
    {
        Logger.Instance.Info("Click on start button");
        StartLink.Click();
    }
}