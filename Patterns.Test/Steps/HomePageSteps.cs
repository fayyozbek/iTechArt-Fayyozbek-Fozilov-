using NUnit.Allure.Attributes;

namespace Patterns.Test.Steps;

public class HomePageSteps
{
    public HomePageSteps(Browser browser)
    {
        Browser = browser;
    }

    private Browser Browser { get; }

    private HomePage HomePage => new(Browser);

    [AllureStep("Login step")]
    public InventoryPageSteps Login(UserModel user)
    {
        HomePage.OpenPage();
        HomePage
            .InputUsername(user.Username)
            .InputPassword(user.Password)
            .ClickLogin();
        return new InventoryPageSteps(Browser);
    }
}