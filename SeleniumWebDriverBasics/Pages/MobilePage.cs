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

    private WebDriverWait _wait => new(WebDriver, TimeSpan.FromSeconds(5));
    
    private readonly By _appleCheckBoxLocator = OnlinerXPath.XPathQueryGenerator("value", "apple", "parent::*");

    private IWebElement _appleCheckBox => WebDriver.FindElement(_appleCheckBoxLocator);
    
    private readonly By _honorCheckBoxLocator = OnlinerXPath.XPathQueryGenerator("value", "honor", "parent::*");

    private IWebElement _honorleCheckBox => WebDriver.FindElement(_honorCheckBoxLocator);

    private readonly By _honorLabelLocator =
        OnlinerXPath.XPathQueryGenerator("data-bind", "removeTag", "span[contains(text(), \"HONOR\")]");

    private readonly By _honorTitleLocator = OnlinerXPath.XPathToHonorTitles;

    private readonly By _appleFirstElementInTheListLocator = OnlinerXPath.XPathForFirstProduct;

    private IWebElement _appleFirstElementInTheList => WebDriver.FindElement(_appleFirstElementInTheListLocator);

    private readonly By _appleThirdElementInTheListLocator = OnlinerXPath.XPathForThirdProduct;

    private IWebElement _appleThirdElementInTheList => WebDriver.FindElement(_appleThirdElementInTheListLocator);
    
    private readonly By _compareButtonLocator = OnlinerXPath.XPathQueryGenerator("compare-button__sub_main");
    
    private readonly By _compareButtonSpanLocator = OnlinerXPath.XPathQueryGenerator("class","compare-button__sub_main", "span");

    private IWebElement _compareButtonSpan => WebDriver.FindElement(_compareButtonSpanLocator);

    private IWebElement _compareButton => WebDriver.FindElement(_compareButtonLocator);
    
    public bool IsItemsAdded => _compareButtonSpan.Text.Contains("2");

    private IWebElement _honorLabel => WebDriver.FindElement(_honorLabelLocator);

    public void ClickOnCheckBoxes()
    {
        ScrollToView(_appleCheckBox);
        _appleCheckBox.Click();
        _honorleCheckBox.Click();
    }

    public void ClickHonorRemoveTag()
    {
        _honorLabel.Click();
    }

    public bool IsAviableHonorTitles
    {
        get
        {
            try
            {
                _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_honorTitleLocator));
                return !WebDriver.FindElement(_honorTitleLocator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
    }

    public void ClickFirstAndThirdProduct()
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(_appleFirstElementInTheListLocator));
        _appleFirstElementInTheList.Click();
        _wait.Until(ExpectedConditions.ElementToBeClickable(_appleThirdElementInTheListLocator));
        _appleThirdElementInTheList.Click();
    }

    public void ClickOnCompareButton()
    {
        _compareButton.Click();
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