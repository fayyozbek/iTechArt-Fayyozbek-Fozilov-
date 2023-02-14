using Patterns.Test.Components;
using Patterns.Test.Pages;

namespace Patterns.Test;

public class InventoryPage : BasePage
{
    public InventoryPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => LocatorsXPath.XPathQueryGenerator("title");
    protected override string UrlPath { get; }

    private InventoryPageComponents InventoryPageComponents => new();

    public void ClickItem()
    {
        InventoryPageComponents.ClickInventoryLink();
    }
    public string GetClickedItemName()
    {
        return InventoryPageComponents.InventoryItemName.GetText();
    }

    public string GetClickedItemDescrition() => InventoryPageComponents.InventoryItemDescription.GetText();

    public string GetClickedItemPrice() => InventoryPageComponents.InventoryItemPrice.GetText();
    
    public InventoryPage ClickAddAndRemoveBtn()
    {
        Components.AddToCartBtn.Click();
        return this;
    }
    
    // public 
}