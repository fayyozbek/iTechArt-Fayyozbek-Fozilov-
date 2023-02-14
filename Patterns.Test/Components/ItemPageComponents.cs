namespace Patterns.Test.Components;

public class ItemPageComponents
{
    private readonly By _itemNameLocator = LocatorsXPath.XPathQueryGenerator("inventory_details_name");
    
    private readonly By _itemDescriptionLocator = LocatorsXPath.XPathQueryGenerator("class","inventory_details_desc", "div[contains(@class,\"inventory_details_desc\")]");
    
    private readonly By _itemPriceLocator = LocatorsXPath.XPathQueryGenerator("inventory_details_price");

    public Label ItemName => new(_itemNameLocator, "Item name");
    
    public Label ItemDescription => new(_itemDescriptionLocator, "Item name");
    
    public Label ItemPrice => new(_itemPriceLocator, "Item name");

    
}