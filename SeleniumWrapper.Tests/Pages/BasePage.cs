using OpenQA.Selenium;
using SeleniumWrapper.Core.Forms;
using SeleniumWrapper.Core.Utilities;
using SeleniumWrapper.Tests.Configurations;

namespace SeleniumWrapper.Tests.Pages;

public abstract class BasePage : BaseForm
{
    protected Browser Browser { get; }
    
    public BasePage(BaseElement uniqueElement, string pageName) : base(uniqueElement, pageName)
    {
    }

    protected override By UniqueWebLocator { get; }
    
    private readonly string _baseUrl = AppConfiguration.BaseUrl;

    protected BasePage(Browser browser) : base(browser)
    {
        Browser = browser;
    }

    protected abstract string UrlPath { get; }
    
    public void OpenPage()
    {
        var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        Logger.Instance.Info(uri.ToString());
        Browser.GoToUrl(uri);
        WaitForPageOpened();
    }
    
}