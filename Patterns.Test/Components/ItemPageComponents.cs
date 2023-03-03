namespace Patterns.Test.Components;

public class ItemPageComponents
{
    private readonly By _itemPriceLocator =
        LocatorsXPath.XPathQueryGenerator("price");
   
    public Label ItemPrice => new(_itemPriceLocator, "Inventory Item Price");
}