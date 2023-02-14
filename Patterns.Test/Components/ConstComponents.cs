namespace Patterns.Test.Components;

public class ConstComponents
{
    private readonly By _cartBtnLocator = LocatorsXPath.XPathQueryGenerator("shopping_cart_link");
    
    private readonly By _burgerMenuBtnLocator = LocatorsXPath.XPathQueryGenerator("id","react-burger-menu-btn");

    private readonly By _logoutBtnLocator = LocatorsXPath.XPathQueryGenerator("id","logout_sidebar_link");
    
    private readonly By _titleLblLocator = LocatorsXPath.XPathQueryGenerator("title");
    
    private readonly By _addToCartBtnLocator = LocatorsXPath.XPathQueryGenerator( "btn_inventory");

    
    public Button CartBtn => new(_cartBtnLocator, "Cart button");

    public Button BurgerMenuBtn => new(_burgerMenuBtnLocator, "Burger Menu");

    public Button LogoutButton => new(_logoutBtnLocator, "Logout button");

    public Label TitleLbl => new(_titleLblLocator, "Title label");
    
    public Button AddToCartBtn => new(_addToCartBtnLocator, "Add to cart button");


}