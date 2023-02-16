using NUnit.Allure.Attributes;

namespace Patterns.Test.Steps;

public class HomePageSteps
{
    private Browser Browser { get;  }

    public HomePageSteps(Browser browser)
    {
        Browser = browser;
    }

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