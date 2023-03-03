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

    public string GetItemName()
    {
        return Components.ItemName.GetText();
    }

    public string GetItemDescription()
    {
        return Components.ItemDescription.GetText();
    }

    public string GetItemPrice()
    {
        return Components.ItemPrice.GetText();
    }

    public void OpenPage()
    {
        var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        Logger.Instance.Info(uri.ToString());
        Browser.GoToUrl(uri);
        WaitForPageOpened();
    }

    public BasePage ClickBurgerMenu()
    {
        Components.BurgerMenuBtn.Click();
        return this;
    }

    public HomePage ClickLogout()
    {
        Components.LogoutButton.Click();
        return new HomePage(Browser);
    }
}