using Patterns.Test.Configurations;
using Patterns.Test.Steps;

namespace Patterns.Test.Tests;

public class BaseTest
{
    protected Browser Browser { get; private set; }

    protected HomePageSteps HomePageSteps { get; private set; }

    protected InventoryPageSteps InventoryPageSteps { get; private set; }

    protected ItemPageSteps ItemPageSteps { get; private set; }

    protected CartPageSteps CartPageSteps { get; private set; }

    [SetUp]
    public void SetUp()
    {
        Browser = BrowserService.StartBrowser(AppConfiguration.BrowserModel);

        HomePageSteps = new HomePageSteps(Browser);
        InventoryPageSteps = new InventoryPageSteps(Browser);
        ItemPageSteps = new ItemPageSteps(Browser);
        CartPageSteps = new CartPageSteps(Browser);
    }

    [TearDown]
    public void TearDown()
    {
        Browser.Quit();
    }
}