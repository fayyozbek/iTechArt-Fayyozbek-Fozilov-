using Patterns.Test.Components;

namespace Patterns.Test.Pages;

public class CheckoutPage : BasePage
{
    public CheckoutPage(IBrowser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => LocatorsXPath.XPathQueryGenerator("complete-header");
    protected override string UrlPath { get; }

    private CheckoutPageComponents CheckoutPageComponents => new();

    public CheckoutPage InputFirstName(string firstName)
    {
        CheckoutPageComponents.FirstNameTxt.Input(firstName);
        return this;
    }

    public CheckoutPage InputLastName(string lastName)
    {
        CheckoutPageComponents.LastNameTxt.Input(lastName);
        return this;
    }

    public CheckoutPage InputZipCode(string zipCode)
    {
        CheckoutPageComponents.ZipCodeTxt.Input(zipCode);
        return this;
    }

    public CheckoutPage ClickNextStep()
    {
        CheckoutPageComponents.NextStepBtn.Click();
        return this;
    }
}