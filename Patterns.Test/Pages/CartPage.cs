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

    public CheckoutPage ClickCheckoutBtn()
    {
        CartPageComponents.CheckoutBtn.Click();
        return new CheckoutPage(Browser);
    }


    public string GetQuantityTxt => CartPageComponents.QuantityLbl.GetText();

    public string GetItemName() => Components.ItemName.GetText();
    
    public string GetItemDescription() => CartPageComponents.ItemInCartDescription.GetText();

    public string GetItemPrice() => Components.ItemPrice.GetText();
    
    public CartPage ClickRemoveBtn()
    {
        Components.AddToCartBtn.Click();
        return this;
    }

}