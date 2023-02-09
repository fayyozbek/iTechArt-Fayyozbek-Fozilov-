using SeleniumWrapper.Core.BrowserConfiguration;
using SeleniumWrapper.Tests.Configurations;
using SeleniumWrapper.Tests.Pages;

namespace SeleniumWrapper.Tests.Tests;

public class BaseTest
{
    protected Browser Browser { get; private set; }
    
    protected TvCategoryPage TvCategoryPage { get; private set; }
    
    [SetUp]
    public void SetUp()
    {
       Browser = BrowserService.StartBrowser(AppConfiguration.BrowserModel);

       TvCategoryPage = new TvCategoryPage(Browser);
    }

    [TearDown]

    public void TearDown()
    {
        Browser.Quit();
    }
}