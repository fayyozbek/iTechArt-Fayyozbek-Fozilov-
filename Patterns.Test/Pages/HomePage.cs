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
    
    public HomePage InputUsernameAndPassword(string username, string password)
    {
        HomePageComponents.
            InputUsername(username)
            .InputPassword(password);
        return this;
    }

   
    public void ClickLogin()
    {
        HomePageComponents.ClickLoginBtn();
    }

   
}