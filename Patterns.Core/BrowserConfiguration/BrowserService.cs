namespace Patterns.Core.BrowserConfiguration;

public static class BrowserService
{
    public static BrowserModel BrowserModel { get; private set; }
    
    private static readonly ThreadLocal<IBrowser> BrowserContainer = new ThreadLocal<IBrowser>();
    
    private static readonly ThreadLocal<BrowserFactory> BrowserFactoryContainer = new ThreadLocal<BrowserFactory>();

    private static bool IsApplicationStarted() => BrowserContainer.IsValueCreated && BrowserContainer.Value.IsStarted;

    public static Browser StartBrowser(BrowserModel browserModel)
    {
        BrowserModel = browserModel;
        var browser = (Browser)GetBrowser();
        return browser;
    }

    public static Browser Browser => (Browser)GetBrowser();
     
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