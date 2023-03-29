namespace Patterns.Test;

public class InventoryPage : BasePage
{
    public InventoryPage(IBrowser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => LocatorsXPath.XPathQueryGenerator("title");
    
    protected override string UrlPath { get; }

    public void ClickItem()
    {
        Components.ItemLink.Click();
    }

    public InventoryPage ClickAddAndRemoveBtn()
    {
        Components.AddToCartBtn.Click();
        return this;
    }

    public CartPage ClickCartBtn()
    {
        Components.CartBtn.Click();
        return new CartPage(Browser);
    }
}