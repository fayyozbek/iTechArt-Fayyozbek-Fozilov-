using NUnit.Allure.Attributes;

namespace Patterns.Test.Steps;

public class CheckoutPageSteps
{
    public CheckoutPageSteps(IBrowser browser)
    {
        Browser = browser;
    }

    private IBrowser Browser { get; }

    private CheckoutPage CheckoutPage => new(Browser);

    public bool IsCompleteCheckout => CheckoutPage.IsPageOpened;
    
    [AllureStep("Full fill user's details")]
    public CheckoutPageSteps InputUserInfo(UserModel user)
    {
        CheckoutPage
            .InputFirstName(user.FirstName)
            .InputLastName(user.LastName)
            .InputZipCode(user.ZipCode);
        return this;
    }

    [AllureStep("Checkout")]
    public CheckoutPageSteps GoToNextStep()
    {
        CheckoutPage.ClickNextStep();
        return this;
    }
}