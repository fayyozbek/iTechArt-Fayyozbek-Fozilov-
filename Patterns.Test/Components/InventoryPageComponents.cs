namespace Patterns.Test.Components;

public class InventoryPageComponents
{
    private readonly By _inventoryItemNameLocator = LocatorsXPath.XPathQueryGenerator("id", "item_4_title_link", "div");
    
    private readonly By _inventoryItemLinkLocator = LocatorsXPath.XPathQueryGenerator("id", "item_4_title_link");

    private Label InventoryItemName => new(_inventoryItemNameLocator, "Inventory Item Name");
    
    private Label InventoryItemLink => new(_inventoryItemLinkLocator, "Inventory Item Link");

    public InventoryPageComponents ClickInventoryLink()
    {
        InventoryItemLink.Click();
        return this;
    }

    public string GetTextInventoryItemName => InventoryItemName.GetText();

}