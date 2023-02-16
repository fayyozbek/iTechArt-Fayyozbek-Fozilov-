namespace Patterns.Test.Components;

public class CartPageComponents
{
    private readonly By _itemInCartNameLocator = LocatorsXPath.XPathQueryGenerator("inventory_item_name");

    private readonly By _checkoutBtnLocator = LocatorsXPath.XPathQueryGenerator("id", "checkout");

    public Label ItemInCartName => new(_itemInCartNameLocator, "Name of item in the cart");

    public Button CheckoutBtn => new(_checkoutBtnLocator, "Checkout button");
}