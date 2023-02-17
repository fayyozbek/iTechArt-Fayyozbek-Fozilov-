using Patterns.Test.Components;

namespace Patterns.Test.Pages;

public class CartPage : BasePage
{
    public CartPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => LocatorsXPath.XPathQueryGenerator("cart_list");
    protected override string UrlPath { get; }

    private CartPageComponents CartPageComponents => new();


    public string GetQuantityTxt => CartPageComponents.QuantityLbl.GetText();

    public CheckoutPage ClickCheckoutBtn()
    {
        CartPageComponents.CheckoutBtn.Click();
        return new CheckoutPage(Browser);
    }

    public string GetItemName()
    {
        return Components.ItemName.GetText();
    }

    public string GetItemDescription()
    {
        return CartPageComponents.ItemInCartDescription.GetText();
    }

    public string GetItemPrice()
    {
        return Components.ItemPrice.GetText();
    }

    public CartPage ClickRemoveBtn()
    {
        Components.AddToCartBtn.Click();
        return this;
    }
}