using Patterns.Test.Configurations;
using Patterns.Test.Pages;

namespace Patterns.Test.Tests;

public class BaseTest
{
    protected Browser Browser { get; private set; }
    

    [SetUp]
    public void SetUp()
    {
       Browser = BrowserService.StartBrowser(AppConfiguration.BrowserModel);

       
    }

    [TearDown]

    public void TearDown()
    {
       Browser.Quit();
    }
}