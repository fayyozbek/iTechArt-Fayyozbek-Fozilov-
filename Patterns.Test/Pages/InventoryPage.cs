using Patterns.Test.Components;
using Patterns.Test.Pages;

namespace Patterns.Test;

public class InventoryPage : BasePage
{
    public InventoryPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => LocatorsXPath.XPathQueryGenerator("title");
    protected override string UrlPath { get; }

    private InventoryPageComponents InventoryPageComponents => new();

    public string GetClickedItemName()
    {
        return InventoryPageComponents
            .ClickInventoryLink()
            .GetTextInventoryItemName;
    }
}