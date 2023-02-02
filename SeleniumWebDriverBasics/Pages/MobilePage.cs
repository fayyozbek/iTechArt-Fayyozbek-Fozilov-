using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumWebDriverBasics.Locators;

namespace SeleniumWebDriverBasics.Pages;

public class MobilePage : BasePage
{
    public MobilePage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => OnlinerXPath.XPathQueryGenerator( "header_title");
    
    protected override string UrlPath => string.Empty;

    private WebDriverWait Wait => new(WebDriver, TimeSpan.FromSeconds(5));
    
    private readonly By _appleCheckBoxLocator = OnlinerXPath.XPathQueryGenerator("value", "apple", "parent::*");

    private IWebElement AppleCheckBox => WebDriver.FindElement(_appleCheckBoxLocator);
    
    private readonly By _honorCheckBoxLocator = OnlinerXPath.XPathQueryGenerator("value", "honor", "parent::*");

    private IWebElement HonorleCheckBox => WebDriver.FindElement(_honorCheckBoxLocator);

    private readonly By _honorLabelLocator =
        OnlinerXPath.XPathQueryGenerator("data-bind", "removeTag", "span[contains(text(), \"HONOR\")]");

    private readonly By _honorTitleLocator = OnlinerXPath.XPathToHonorTitles;

    private readonly By _appleFirstElementInTheListLocator = OnlinerXPath.XPathForFirstProduct;

    private IWebElement AppleFirstElementInTheList => WebDriver.FindElement(_appleFirstElementInTheListLocator);

    private readonly By _appleThirdElementInTheListLocator = OnlinerXPath.XPathForThirdProduct;

    private IWebElement AppleThirdElementInTheList => WebDriver.FindElement(_appleThirdElementInTheListLocator);
    
    private readonly By _compareButtonLocator = OnlinerXPath.XPathQueryGenerator("compare-button__sub_main");
    
    private readonly By _compareButtonSpanLocator = OnlinerXPath.XPathQueryGenerator("class","compare-button__sub_main", "span");

    private IWebElement CompareButtonSpan => WebDriver.FindElement(_compareButtonSpanLocator);

    private IWebElement CompareButton => WebDriver.FindElement(_compareButtonLocator);
    
    public string QuantityOfItemsAdded => CompareButtonSpan.Text;

    private IWebElement HonorLabel => WebDriver.FindElement(_honorLabelLocator);

    [AllureStep("Select checkboxes")]
    public void ClickOnCheckBoxes()
    {
        ScrollToView(AppleCheckBox);
        Logger.Instance.Info($"Select checkboxes {AppleCheckBox} and {HonorleCheckBox}");

        AppleCheckBox.Click();
        HonorleCheckBox.Click();
    }

    [AllureStep("Remove honor tag")]
    public void ClickHonorRemoveTag()
    {
        Logger.Instance.Info($"Remove {HonorLabel}");
        HonorLabel.Click();
    }

    public bool IsAviableHonorTitles
    {
        get
        {
            try
            {
                Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_honorTitleLocator));
                return !WebDriver.FindElement(_honorTitleLocator).Displayed;
            }
            catch (NoSuchElementException)
            {
                Logger.Instance.Info("All honor products removed");
                return true;
            }
        }
    }

    [AllureStep("Select first and third products ")]
    public void ClickFirstAndThirdProduct()
    {
        Wait.Until(ExpectedConditions.ElementToBeClickable(_appleFirstElementInTheListLocator));
        Logger.Instance.Info($"Select {AppleFirstElementInTheList}");
        AppleFirstElementInTheList.Click();
        Wait.Until(ExpectedConditions.ElementToBeClickable(_appleThirdElementInTheListLocator));
        Logger.Instance.Info($"Select {AppleThirdElementInTheList}");
        AppleThirdElementInTheList.Click();
    }

    [AllureStep("Click compare button")]
    public void ClickOnCompareButton()
    {
        Logger.Instance.Info($"Click on {CompareButton}");
        CompareButton.Click();
    }
    
    public void ScrollToView(IWebElement element)
    {
        if (element.Location.Y > 200)
        {
            var js = $"window.scrollTo({0}, {element.Location.Y-80})";
            IJavaScriptExecutor scriptExecutor= WebDriver as IJavaScriptExecutor;
            scriptExecutor.ExecuteScript(js);
        }
    }
}