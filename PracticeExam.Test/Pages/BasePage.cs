using PracticeExam.Core.BrowserConfiguration;
using PracticeExam.Core.Forms;
using PracticeExam.Test.Configurations;

namespace PracticeExam.Test.Pages;

public abstract class BasePage : BaseForm
{
    private readonly string _baseUrl = AppConfiguration.BaseUrl;

    protected BasePage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator { get; }

    protected abstract string UrlPath { get; }

    public void OpenPage()
    {
        var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        Browser.GoToUrl(uri);
        WaitForPageOpened();
    }
}