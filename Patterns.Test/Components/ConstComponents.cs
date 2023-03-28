namespace Patterns.Test.Components;

public class ConstComponents : BaseComponents
{
    private readonly By _addToCartBtnLocator = LocatorsXPath.XPathQueryGenerator("btn_small");

    private readonly By _burgerMenuBtnLocator = LocatorsXPath.XPathQueryGenerator("id", "react-burger-menu-btn");
    
    private readonly By _cartBtnLocator = LocatorsXPath.XPathQueryGenerator("shopping_cart_link");

    private readonly By _itemDescriptionLocator =
        LocatorsXPath.XPathQueryGenerator("class", "desc", "div[contains(@class, \"desc\")]");

    private readonly By _itemLinkLocator = LocatorsXPath.XPathQueryGenerator("id", "item_4_title_link");

    private readonly By _itemNameLocator = LocatorsXPath.XPathQueryGenerator("name");

    private readonly By _itemPriceLocator =
        LocatorsXPath.XPathQueryGenerator("class", "price", "div[contains(@class,\"price\")]");

    private readonly By _logoutBtnLocator = LocatorsXPath.XPathQueryGenerator("id", "logout_sidebar_link");

    private readonly By _titleLblLocator = LocatorsXPath.XPathQueryGenerator("title");

    public IButton CartBtn => Builder.CreateButton(_cartBtnLocator, "Cart button");

    public IButton BurgerMenuBtn => Builder.CreateButton(_burgerMenuBtnLocator, "Burger Menu");

    public IButton LogoutButton => Builder.CreateButton(_logoutBtnLocator, "Logout button");

    public IElement TitleLbl => Builder.CreateLabel(_titleLblLocator, "Title label");

    public IButton AddToCartBtn => Builder.CreateButton(_addToCartBtnLocator, "Add to cart button");
    
    public IElement ItemName => Builder.CreateLabel(_itemNameLocator, "Inventory Item Name");

    public IElement ItemLink => Builder.CreateLabel(_itemLinkLocator, "Inventory Item Link");

    public IElement ItemDescription => Builder.CreateLabel(_itemDescriptionLocator, "Inventory Item Description");

    public IElement ItemPrice => Builder.CreateLabel(_itemPriceLocator, "Inventory Item Price");
}