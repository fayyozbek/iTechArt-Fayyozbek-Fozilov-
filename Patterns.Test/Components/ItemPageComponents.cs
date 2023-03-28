namespace Patterns.Test.Components;

public class ItemPageComponents : BaseComponents
{
    private readonly By _itemPriceLocator =
        LocatorsXPath.XPathQueryGenerator("price");
   
    public IElement ItemPrice => Builder.CreateLabel(_itemPriceLocator, "Inventory Item Price");
}