using NUnit.Allure.Attributes;
using Patterns.Test.Strategy.GetItemStrategy;

namespace Patterns.Test.Steps;

public class CartPageSteps
{
    public CartPageSteps(IBrowser browser)
    {
        Browser = browser;
    }

    private IBrowser Browser { get; }

    private CartPage CartPage => new(Browser);
    
    private IGetItemStrategy GetItemStrategy => new CartPageStrategy(Browser);


    [AllureStep("Get item details")]
    public ItemModel GetItem()
    {
        return GetItemStrategy.GetItem();
    }

    [AllureStep("Go to next step")]
    public CheckoutPageSteps GoToNextStep()
    {
        CartPage.ClickCheckoutBtn();
        return new CheckoutPageSteps(Browser);
    }

    [AllureStep("Remove Item and check that it removed")]
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