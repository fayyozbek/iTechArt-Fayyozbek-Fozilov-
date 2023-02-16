using NUnit.Allure.Attributes;

namespace Patterns.Test.Steps;

public class InventoryPageSteps
{
    private Browser Browser { get;  }

    public InventoryPageSteps(Browser browser)
    {
        Browser = browser;
    }

    private InventoryPage InventoryPage => new(Browser);

    [AllureStep("Get expected result")]
    public ItemModel GetItem()
    { 
        return new ItemModel()
        {
            Name = InventoryPage.GetItemName(),
            Description = InventoryPage.GetItemDescription(),
            Price = InventoryPage.GetItemPrice()
        };
    }

    [AllureStep("Go to item description")]
    public void GoToItemDescription()
    {
        InventoryPage.ClickItem();
    }

    [AllureStep("Add item to cart and go to the cart ")]
    public CartPageSteps GoToCart()
    {
        InventoryPage
            .ClickAddAndRemoveBtn()
            .ClickCartBtn();
        return new CartPageSteps( Browser);
    }

    [AllureStep("Logout")]
    public bool Logout()
    {
        return InventoryPage
            .ClickBurgerMenu()
            .ClickLogout()
            .IsPageOpened;
    }

}