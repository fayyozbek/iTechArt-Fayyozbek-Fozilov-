namespace Patterns.Test.Pages;

public class ItemPage : BasePage
{
    public ItemPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => LocatorsXPath.XPathQueryGenerator("inventory_item_container");
    
    protected override string UrlPath { get; }

    public ItemPage ClickAddAndRemoveBtn()
    {
        Components.AddToCartBtn.Click();
        return this;
    }
}