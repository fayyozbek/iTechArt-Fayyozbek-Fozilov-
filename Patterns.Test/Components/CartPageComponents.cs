namespace Patterns.Test.Components;

public class CartPageComponents
{
    private readonly By _itemInCartNameLocator = LocatorsXPath.XPathQueryGenerator("inventory_item_name");

    private readonly By _checkoutBtnLocator = LocatorsXPath.XPathQueryGenerator("id", "checkout");

    private readonly By _quantityLblLocator = LocatorsXPath.XPathQueryGenerator("class","cart_item","cart_quantity");

    public Label ItemInCartName => new(_itemInCartNameLocator, "Name of item in the cart");

    public Button CheckoutBtn => new(_checkoutBtnLocator, "Checkout button");

    public Label QuantityLbl => new(_quantityLblLocator, "Quantitny Label");
    

    private readonly By _itemInCartDescriptionLocator = LocatorsXPath.XPathQueryGenerator( "class","item", "div[contains(@class, \"desc\")]");

    public Label ItemInCartDescription => new(_itemInCartDescriptionLocator, "Inventory Item Description");
}