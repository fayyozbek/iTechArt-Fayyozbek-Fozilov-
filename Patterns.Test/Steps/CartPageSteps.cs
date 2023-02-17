using NUnit.Allure.Attributes;

namespace Patterns.Test.Steps;

public class CartPageSteps
{
    public CartPageSteps(Browser browser)
    {
        Browser = browser;
    }

    private Browser Browser { get; }

    private CartPage CartPage => new(Browser);

    [AllureStep("Get item details")]
    public ItemModel GetItem()
    {
        CartPage.WaitForPageOpened();
        return new ItemModel
        {
            Name = CartPage.GetItemName(),
            Description = CartPage.GetItemDescription(),
            Price = CartPage.GetItemPrice()
        };
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