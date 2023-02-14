using Patterns.Test.Configurations;
using Patterns.Test.Pages;
using Patterns.Test.Steps;

namespace Patterns.Test.Tests;

public class BaseTest
{
    protected Browser Browser { get; private set; }
    
    protected HomePageSteps HomePageSteps { get; private set; }
    
    protected InventoryPageSteps InventoryPageSteps { get; private set; }

    protected ItemPageSteps ItemPageSteps { get; private set; }
    
    [SetUp]
    public void SetUp()
    {
       Browser = BrowserService.StartBrowser(AppConfiguration.BrowserModel);

       HomePageSteps = new(Browser);
       InventoryPageSteps = new(Browser);
       ItemPageSteps = new(Browser);
    }

    [TearDown]
    public void TearDown()
    {
     //  Browser.Quit();
    }
}