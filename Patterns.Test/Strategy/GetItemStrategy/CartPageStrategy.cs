namespace Patterns.Test.Strategy.GetItemStrategy;

public class CartPageStrategy : IGetItemStrategy
{
    public CartPageStrategy(Browser browser)
    {
        Browser = browser;
    }
    private CartPage CartPage => new(Browser);
    private Browser Browser { get; }
    
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
}