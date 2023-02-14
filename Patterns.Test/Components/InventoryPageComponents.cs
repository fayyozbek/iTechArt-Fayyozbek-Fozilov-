namespace Patterns.Test.Components;

public class InventoryPageComponents
{
    private readonly By _inventoryItemNameLocator = LocatorsXPath.XPathQueryGenerator("id", "item_4_title_link", "div");
    
    private readonly By _inventoryItemLinkLocator = LocatorsXPath.XPathQueryGenerator("id", "item_4_title_link");

    private readonly By _inventoryItemDescriptionLocator = LocatorsXPath.XPathQueryGenerator("id", "item_4_title_link", "following-sibling::*[contains(@class,\"inventory_item_desc\")]");

    private readonly By _inventoryItemPriceLocator = LocatorsXPath.XPathQueryGenerator("id", "item_4_title_link", "parent::div//parent::*//*[contains(@class, \"inventory_item_price\")]");



    public Label InventoryItemName => new(_inventoryItemNameLocator, "Inventory Item Name");
    
    private Label InventoryItemLink => new(_inventoryItemLinkLocator, "Inventory Item Link");

    public Label InventoryItemDescription => new(_inventoryItemDescriptionLocator, "Inventory Item Description");

    public Label InventoryItemPrice => new(_inventoryItemPriceLocator, "Inventory Item Price");

    
    

    public InventoryPageComponents ClickInventoryLink()
    {
        InventoryItemLink.Click();
        return this;
    }
}