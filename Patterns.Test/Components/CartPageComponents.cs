namespace Patterns.Test.Components;

public class CartPageComponents :BaseComponents
{
    private readonly By _checkoutBtnLocator = LocatorsXPath.XPathQueryGenerator("id", "checkout");


    private readonly By _itemInCartDescriptionLocator =
        LocatorsXPath.XPathQueryGenerator("class", "item", "div[contains(@class, \"desc\")]");

    private readonly By _itemInCartNameLocator = LocatorsXPath.XPathQueryGenerator("inventory_item_name");

    private readonly By _quantityLblLocator = LocatorsXPath.XPathQueryGenerator("class", "cart_item", "cart_quantity");

    public IElement ItemInCartName => Builder.CreateLabel(_itemInCartNameLocator, "Name of item in the cart");

    public IButton CheckoutBtn => Builder.CreateButton(_checkoutBtnLocator, "Checkout button");

    public IElement QuantityLbl => Builder.CreateLabel(_quantityLblLocator, "Quantitny IElement");

    public IElement ItemInCartDescription => Builder.CreateLabel(_itemInCartDescriptionLocator, "Inventory Item Description");
}