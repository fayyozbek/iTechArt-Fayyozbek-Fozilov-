namespace Patterns.Test.Steps;

public class CartPageSteps
{
    private Browser Browser { get;  }

    public CartPageSteps(Browser browser)
    {
        Browser = browser;
    }

    private CartPage CartPage => new(Browser);

    public CheckoutPageSteps GoToNextStep()
    {
        CartPage.ClickCheckoutBtn();
        return new CheckoutPageSteps(Browser);
    }
}