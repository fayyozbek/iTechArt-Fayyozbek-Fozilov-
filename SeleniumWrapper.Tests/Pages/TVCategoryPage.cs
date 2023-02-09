using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Selenium.Lection.SimpleWrapper.Core;
using SeleniumWrapper.Core.BrowserConfiguration;
using SeleniumWrapper.Core.Elements;
using SeleniumWrapper.Core.Utilities;

namespace SeleniumWrapper.Tests.Pages;

public class TvCategoryPage : BasePage
{
    public TvCategoryPage(BaseElement uniqueElement, string pageName) : base(uniqueElement, pageName)
    {
    }

    public TvCategoryPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//*[contains(@class, \"goods-section-left-top\")]//h3");
    protected override string UrlPath => "/products/category/8";

    private readonly By _firstProductAddToItemBtnLocator = By.XPath("//*[@data-product= \"16470\"]");

    private readonly By _secondProductAddToItemBtnLocator = By.XPath("//*[@data-product= \"16154\"]");

    private readonly By _cartBtnLocator = By.XPath("//*[@class= \"karzinka\"]");

    private readonly By _cartOpenedIndicatorLocator = By.XPath("//*[contains(@class, \"karzinka-open-active\")]");
    
    private readonly By _totalCountLabelLocator= By.XPath("//*[@class= \"totalCount\"]");
    
    private Button FirstProductAddToItemBtn => new(_firstProductAddToItemBtnLocator, "First Product Add To Item Button");
    
    private Button SecondProductAddToItemBtn => new(_secondProductAddToItemBtnLocator, "Second_Product_Add_To_Item_Button");

    private Label CartOpenedIndicator => new(_cartOpenedIndicatorLocator, "Opened indicator of cart");
    
    private Label TotalCountLabel => new(_totalCountLabelLocator, "total count");

    private Button CartBtn => new(_cartBtnLocator, "Cart Button");
    
    [AllureStep("Add two items in cart")]
    public void ClickAddToItem()
    {
        Logger.Instance.Info("Add first product to cart");
        FirstProductAddToItemBtn.Click();
        Logger.Instance.Info("Add Second product to cart");
        SecondProductAddToItemBtn.Click();        
    }

    [AllureStep("Open cart")]
    public void ClickCartBtn()
    {
        Logger.Instance.Info("Open cart");
        CartBtn.Click();
    }

    public bool IsCartOpened => CartOpenedIndicator.IsDisplayed();

    public string totalCount => TotalCountLabel.GetText();
}