using NUnit.Allure.Attributes;

namespace Patterns.Test.Steps;

public class ItemPageSteps
{
    private Browser Browser { get;  }

    public ItemPageSteps(Browser browser)
    {
        Browser = browser;
    }

    private ItemPage ItemPage => new(Browser);

    [AllureStep("Get actual result")]
    public ItemModel GetItem()
    {
        ItemPage.WaitForPageOpened();
        return new ItemModel()
        {
            Name = ItemPage.GetItemName(),
            Description = ItemPage.GetItemDescription(),
            Price = ItemPage.GetItemPrice()
        };
    }
}