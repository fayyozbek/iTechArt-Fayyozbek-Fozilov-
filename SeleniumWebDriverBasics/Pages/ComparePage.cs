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
    
    private const string _expectedText = "Краткая информация об отличиях товара от конкурентных моделей и аналогов, сведения о позиционировании на рынке, преемственности и др.";
    
    private readonly By _descriptionButtonLocator = OnlinerXPath.XPathQueryGenerator("data-tip-term", "Описание");

    private IWebElement _descriptionButton => WebDriver.FindElement(_descriptionButtonLocator);

    public bool IsDecriptionOpened => _descriptionButton.GetAttribute("class").Contains("trigger_visible");

    public bool IsDescriptionRightText => _descriptionButton.GetAttribute("data-tip-text").Contains(_expectedText);

    public void ClickOnDescriptionButton()
    {
        _descriptionButton.Click();
    }
}