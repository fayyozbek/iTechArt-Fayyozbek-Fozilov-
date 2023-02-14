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
            Name = InventoryPage.GetClickedItemName(),
            Description = InventoryPage.GetClickedItemDescrition(),
            Price = InventoryPage.GetClickedItemPrice()
        };
    }

    [AllureStep("Go to item description")]
    public void GoToItemDescription()
    {
        InventoryPage.ClickItem();
    }
    
    
    

}