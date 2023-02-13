using Patterns.Core.Forms;
using Patterns.Test.Configurations;

namespace Patterns.Test.Pages;

public abstract class BasePage : BaseForm
{
    protected Browser Browser { get; }

    private readonly string _baseUrl = AppConfiguration.BaseUrl;

    protected BasePage(Browser browser) : base(browser)
    {
        Browser = browser;
    }

    protected abstract string UrlPath { get; }
    
    
    
}