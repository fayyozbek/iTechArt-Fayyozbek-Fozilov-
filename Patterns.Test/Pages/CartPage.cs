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
    
    
}