namespace Patterns.Test.Strategy.GetItemStrategy;

public class ItemPageStrategy : IGetItemStrategy
{
    public ItemPageStrategy(Browser browser)
    {
        Browser = browser;
    }
    private ItemPage ItemPage => new(Browser);
    private Browser Browser { get; }
    
    public ItemModel GetItem()
    {
        
        ItemPage.WaitForPageOpened();
        return new ItemModel
        {
            Name = ItemPage.GetItemName(),
            Description = ItemPage.GetItemDescription(),
            Price = ItemPage.GetItemPrice()
        };
    }
}