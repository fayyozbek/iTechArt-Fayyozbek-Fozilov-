using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumWebDriverBasics.Locators;

namespace SeleniumWebDriverBasics.Pages;

public class ComparePage : BasePage
{
    public ComparePage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => OnlinerXPath.XPathQueryGenerator( "__clear button");
    protected override string UrlPath { get; }
    
    
    private readonly By _descriptionButtonLocator = OnlinerXPath.XPathQueryGenerator("data-tip-term", "Описание");

    private IWebElement DescriptionButton => WebDriver.FindElement(_descriptionButtonLocator);

    public bool IsDecriptionOpened => DescriptionButton.GetAttribute("class").Contains("trigger_visible");

    public string DescriptionDataTipText => DescriptionButton.GetAttribute("data-tip-text");

    [AllureStep("Click Description Button")]
    public void ClickOnDescriptionButton()
    {
        Logger.Instance.Info($"CLick on button {DescriptionButton}");
        DescriptionButton.Click();
    }
}