using Patterns.Test.Components;

namespace Patterns.Test.Pages;

public class ItemPage : BasePage
{
    public ItemPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => LocatorsXPath.XPathQueryGenerator("inventory_item_container");
    protected override string UrlPath { get; }

    private ItemPageComponents ItemPageComponents => new();

    public string ItemName() => ItemPageComponents.ItemName.GetText();
    public string ItemDescription() => ItemPageComponents.ItemDescription.GetText();

    public string ItemPrice() => ItemPageComponents.ItemPrice.GetText();
    public ItemPage ClickAddAndRemoveBtn()
    {
        Components.AddToCartBtn.Click();
        return this;
    }
}