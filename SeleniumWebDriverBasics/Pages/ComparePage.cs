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
    
    private const string ExpectedText = "Краткая информация об отличиях товара от конкурентных моделей и аналогов, сведения о позиционировании на рынке, преемственности и др.";
    
    private readonly By _descriptionButtonLocator = OnlinerXPath.XPathQueryGenerator("data-tip-term", "Описание");

    private IWebElement DescriptionButton => WebDriver.FindElement(_descriptionButtonLocator);

    public bool IsDecriptionOpened => DescriptionButton.GetAttribute("class").Contains("trigger_visible");

    public bool IsDescriptionRightText => DescriptionButton.GetAttribute("data-tip-text").Contains(ExpectedText);

    public void ClickOnDescriptionButton()
    {
        DescriptionButton.Click();
    }
}