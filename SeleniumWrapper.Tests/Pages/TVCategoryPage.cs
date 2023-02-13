using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SeleniumWrapper.Tests.Pages;

public class TvCategoryPage : BasePage
{
    public TvCategoryPage(BaseElement uniqueElement, string pageName) : base(uniqueElement, pageName)
    {
    }

    public TvCategoryPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => LocatorsXPath.XPathQueryGenerator("class","goods-section-left-top","h3");
    protected override string UrlPath => "/products/category/8";

    private readonly By _firstProductAddToItemBtnLocator = LocatorsXPath.XPathQueryGenerator("data-product","16470");

    private readonly By _secondProductAddToItemBtnLocator = LocatorsXPath.XPathQueryGenerator("data-product","16154");

    private readonly By _cartBtnLocator = LocatorsXPath.XPathQueryGenerator("class","karzinka");

    private readonly By _cartOpenedIndicatorLocator = LocatorsXPath.XPathQueryGenerator("class, \"karzinka-open-active\")]");
    
    private readonly By _totalCountLabelLocator= LocatorsXPath.XPathQueryGenerator("class","totalCount");
    
    private readonly By _cartItemsCountLocator= LocatorsXPath.XPathQueryGenerator("class","cart_items_count");

    private readonly By _orderBtn = LocatorsXPath.XPathQueryGenerator("class","karzinka-open-bottom-block-a2");
    
    private Button FirstProductAddToItemBtn => new(_firstProductAddToItemBtnLocator, "First Product Add To Item Button");
    
    private Button SecondProductAddToItemBtn => new(_secondProductAddToItemBtnLocator, "Second_Product_Add_To_Item_Button");

    private Label CartOpenedIndicator => new(_cartOpenedIndicatorLocator, "Opened indicator of cart");
    
    private Label TotalCountLabel => new(_totalCountLabelLocator, "total count");

    private Button CartBtn => new(_cartBtnLocator, "Cart Button");

    private Label CartItemsCount => new(_cartItemsCountLocator, "Cart Items Count");

    private Label OrderBtn => new(_orderBtn, "Order button");
    
    [AllureStep("Add two items in cart")]
    public void ClickAddToItem()
    {
        Logger.Instance.Info("Add first product to cart");
        BrowserService.Browser.BrowserWait.Until(ExpectedConditions.ElementToBeClickable(_firstProductAddToItemBtnLocator));
        FirstProductAddToItemBtn.Click();
        BrowserService.Browser.BrowserWait.Until(_ => CartItemsCount.GetText().Contains("1"));

        Logger.Instance.Info("Add Second product to cart");
        SecondProductAddToItemBtn.Click();
        BrowserService.Browser.BrowserWait.Until(_ => CartItemsCount.GetText().Contains("2"));
    }

    [AllureStep("Open cart")]
    public void ClickCartBtn()
    {
        Logger.Instance.Info("Open cart");
        CartBtn.Click();
        BrowserService.Browser.BrowserWait.Until(_=>TotalCountLabel.GetText().Contains("2"));
    }

    [AllureStep("Click Order button")]
    public void ClickOrderBtn()
    {
        OrderBtn.Click();
    }
    public bool IsCartOpened => CartOpenedIndicator.IsDisplayed();

    public string TotalCount => TotalCountLabel.GetText();
}