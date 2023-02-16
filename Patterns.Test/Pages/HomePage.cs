using Patterns.Test.Components;

namespace Patterns.Test.Pages;

public class HomePage : BasePage
{
    public HomePage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => LocatorsXPath.XPathQueryGenerator("id", "login-button");
    
    protected override string UrlPath { get; }
    
    private HomePageComponents HomePageComponents=> new ();
    
    public HomePage InputPassword(string password)
    {
        HomePageComponents.PasswordTxt.Input(password);
        return this;
    }
    
    public HomePage InputUsername(string username)
    {
        HomePageComponents.UsernameTxt.Input(username);
        return this;
    }

    
   
    public InventoryPage ClickLogin()
    {
        HomePageComponents.LoginBtn.Click();
        return new InventoryPage(Browser);
    }

   
}