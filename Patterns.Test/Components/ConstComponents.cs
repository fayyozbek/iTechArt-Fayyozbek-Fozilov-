namespace Patterns.Test.Components;

public class ConstComponents
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

    public Button CartBtn => new(_cartBtnLocator, "Cart button");

    public Button BurgerMenuBtn => new(_burgerMenuBtnLocator, "Burger Menu");

    public Button LogoutButton => new(_logoutBtnLocator, "Logout button");

    public Label TitleLbl => new(_titleLblLocator, "Title label");

    public Button AddToCartBtn => new(_addToCartBtnLocator, "Add to cart button");
    
    public Label ItemName => new(_itemNameLocator, "Inventory Item Name");

    public Label ItemLink => new(_itemLinkLocator, "Inventory Item Link");

    public Label ItemDescription => new(_itemDescriptionLocator, "Inventory Item Description");

    public Label ItemPrice => new(_itemPriceLocator, "Inventory Item Price");
}