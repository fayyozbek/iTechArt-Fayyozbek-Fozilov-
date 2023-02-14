using Patterns.Core.Forms;
using Patterns.Test.Components;
using Patterns.Test.Configurations;

namespace Patterns.Test.Pages;

public abstract class BasePage : BaseForm
{
   
    private readonly string _baseUrl = AppConfiguration.BaseUrl;

    protected BasePage(Browser browser) : base(browser)
    {
    }

    public ConstComponents Components => new();

    protected abstract string UrlPath { get; }
    
    public void OpenPage()
    {
        var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        Logger.Instance.Info(uri.ToString());
        Browser.GoToUrl(uri);
        WaitForPageOpened(); 
    }

    
}