namespace Patterns.Test.Steps;

public class InventoryPageSteps
{
    private Browser Browser { get;  }

    public InventoryPageSteps(Browser browser)
    {
        Browser = browser;
    }

    private InventoryPage InventoryPage => new(Browser);

    public string GoToItemDescription()
    {
        return InventoryPage.GetClickedItemName();
    }
    
    

}