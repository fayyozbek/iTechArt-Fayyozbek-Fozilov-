using Patterns.Test.Components;

namespace Patterns.Test.Pages;

public class ItemPage : BasePage
{
    public ItemPage(IBrowser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => LocatorsXPath.XPathQueryGenerator("inventory_item_container");
    
    protected override string UrlPath { get; }

    private ItemPageComponents ItemPageComponents => new();
    
    public new string GetItemPrice()
    {
        return ItemPageComponents.ItemPrice.GetText();
    }

    public ItemPage ClickAddAndRemoveBtn()
    {
        Components.AddToCartBtn.Click();
        return this;
    }
}