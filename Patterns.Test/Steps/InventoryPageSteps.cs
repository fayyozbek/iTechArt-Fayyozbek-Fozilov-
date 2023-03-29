using NUnit.Allure.Attributes;

namespace Patterns.Test.Steps;

public class InventoryPageSteps
{
    public InventoryPageSteps(IBrowser browser)
    {
        Browser = browser;
    }

    private IBrowser Browser { get; }

    private InventoryPage InventoryPage => new(Browser);

    [AllureStep("Get expected result")]
    public ItemModel GetItem()
    {
        return new ItemModel
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
        return new CartPageSteps(Browser);
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