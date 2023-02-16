namespace Patterns.Test.Steps;

public class CheckoutPageSteps
{
    private  Browser Browser { get; }
    public CheckoutPageSteps(Browser browser)
    {
        Browser = browser;
    }

    private CheckoutPage CheckoutPage => new(Browser);

    public CheckoutPageSteps InputUserInfo(UserModel user)
    {
        CheckoutPage
            .InputFirstName(user.FirstName)
            .InputLastName(user.LastName)
            .InputZipCode(user.ZipCode);
        return this;
    }

    public CheckoutPageSteps GoToNextStep()
    {
        CheckoutPage.ClickNextStep();
        return this;
    }

    public bool IsCompleteCheckout => CheckoutPage.IsPageOpened;
}