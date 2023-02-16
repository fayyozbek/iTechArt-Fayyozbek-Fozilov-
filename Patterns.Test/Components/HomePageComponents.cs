namespace Patterns.Test.Components;

public class HomePageComponents
{
    private readonly By _loginBtnLocator= LocatorsXPath.XPathQueryGenerator("id", "login-button");
    
    private readonly By _usernameTxtLocator = LocatorsXPath.XPathQueryGenerator("id", "user-name");

    private readonly By _passwordTxtLocator = LocatorsXPath.XPathQueryGenerator("id", "password");

    public Text UsernameTxt => new(_usernameTxtLocator, "Username textfield");
   
    public Text PasswordTxt => new(_passwordTxtLocator, "Password textfield");

    public Button LoginBtn => new(_loginBtnLocator, "Login Button");
    
    public HomePageComponents InputUsername(string username)
    {
        UsernameTxt.Input(username);
        return this;
    }

    public HomePageComponents InputPassword(string password)
    {
        PasswordTxt.Input(password);
        return this;
    }

    public HomePageComponents ClickLoginBtn()
    {
        LoginBtn.Click();
        return this;
    }
}