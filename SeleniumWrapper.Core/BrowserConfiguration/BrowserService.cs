using OpenQA.Selenium.Support.UI;

namespace SeleniumWrapper.Core.BrowserConfiguration;

public static class BrowserService
{
    private static BrowserModel BrowserModel { get; set; }
    private static readonly ThreadLocal<IBrowser> BrowserContainer = new ThreadLocal<IBrowser>();
    
    private static readonly ThreadLocal<BrowserFactory> BrowserFactoryContainer = new ThreadLocal<BrowserFactory>();

    private static bool IsApplicationStarted() => BrowserContainer.IsValueCreated && BrowserContainer.Value.IsStarted;

    public static Browser StartBrowser(BrowserModel browserModel)
    {
        BrowserModel = browserModel;
        var browser = (Browser)GetBrowser();
        browser.BrowserWait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(BrowserModel.ConditionTimeWait));
        return browser;
    }

    public static Browser Browser => (Browser)GetBrowser();
     


    public static bool IsBrowserStarted => IsApplicationStarted();

    private static IBrowser GetBrowser()
    {
        if (!IsApplicationStarted())
        {
            BrowserContainer.Value = BrowserFactory.GetBrowser;
        }

        return BrowserContainer.Value;
    }

    private static BrowserFactory BrowserFactory
    {
        get
        {
            if (!BrowserFactoryContainer.IsValueCreated)
            {
                SetDefaultFactory();
            }
            
            return BrowserFactoryContainer.Value;
        }
        set => BrowserFactoryContainer.Value = value;
    }
    
    private static void SetDefaultFactory()
    {
        BrowserFactory =  new LocalBrowserFactory(BrowserModel);
    }

}