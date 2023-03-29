namespace Patterns.Test.Strategy.GetItemStrategy;

public class CartPageStrategy : IGetItemStrategy
{
    public CartPageStrategy(IBrowser browser)
    {
        Browser = browser;
    }
    private CartPage CartPage => new(Browser);
    private IBrowser Browser { get; }
    
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