namespace Patterns.Test.Components;

public class HomePageComponents : BaseComponents
{
    private readonly By _loginBtnLocator = LocatorsXPath.XPathQueryGenerator("id", "login-button");

    private readonly By _passwordTxtLocator = LocatorsXPath.XPathQueryGenerator("id", "password");

    private readonly By _usernameTxtLocator = LocatorsXPath.XPathQueryGenerator("id", "user-name");

    public IText UsernameTxt => Builder.CreateText(_usernameTxtLocator, "Username textfield");

    public IText PasswordTxt => Builder.CreateText(_passwordTxtLocator, "Password textfield");

    public IButton LoginBtn => Builder.CreateButton(_loginBtnLocator, "Login Button");
}