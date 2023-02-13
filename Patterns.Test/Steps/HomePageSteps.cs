using Patterns.Test.Model;
using Patterns.Test.Pages;

namespace Patterns.Test.Steps;

public class HomePageSteps
{
    private Browser Browser { get;  }

    public HomePageSteps(Browser browser)
    {
        Browser = browser;
    }

    private HomePage HomePage => new(Browser);

    public InventoryPageSteps Login(UserModel user)
    {
        HomePage
            .InputUsernameAndPassword(user.Username, user.Password)
            .ClickLogin();
        return new InventoryPageSteps(Browser);
    }

}