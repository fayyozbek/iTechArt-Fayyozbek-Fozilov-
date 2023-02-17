namespace Patterns.Test.Steps;

public class CartPageSteps
{
    private Browser Browser { get;  }

    public CartPageSteps(Browser browser)
    {
        Browser = browser;
    }

    private CartPage CartPage => new(Browser);

    public ItemModel GetItem()
    { 
        CartPage.WaitForPageOpened();
        return new ItemModel()
        {
            Name = CartPage.GetItemName(),
            Description = CartPage.GetItemDescription(),
            Price = CartPage.GetItemPrice()
        };
    }
    
    public CheckoutPageSteps GoToNextStep()
    {
        CartPage.ClickCheckoutBtn();
        return new CheckoutPageSteps(Browser);
    }

    public bool IsRemovedItem()
    {
            try
            {
                CartPage.ClickRemoveBtn();
                return CartPage.GetQuantityTxt.Equals(null);
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        
    }
    
}