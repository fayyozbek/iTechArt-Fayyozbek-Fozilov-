using PracticeExam.Core.BrowserConfiguration;
using PracticeExam.Core.Forms;
using PracticeExam.Test.Configurations;

namespace PracticeExam.Test.Pages;

public abstract class BasePage : BaseForm
{
    protected override By UniqueWebLocator { get; }
    
    private readonly string _baseUrl = AppConfiguration.BaseUrl;

    protected BasePage(Browser browser) : base(browser)
    {
    }

    protected abstract string UrlPath { get; }
    
    public void OpenPage()
    {
        var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        Browser.GoToUrl(uri);
        WaitForPageOpened();
    }
    
}