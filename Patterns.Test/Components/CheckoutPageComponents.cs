namespace Patterns.Test.Components;

public class CheckoutPageComponents
{
    private readonly By _firstNameTxtLocator = LocatorsXPath.XPathQueryGenerator("id", "first-name");

    private readonly By _lastNameTxtLocator = LocatorsXPath.XPathQueryGenerator("id", "last-name");

    private readonly By _nextStepBtnLocator = LocatorsXPath.XPathQueryGenerator("btn_action");

    private readonly By _zipCodeNameTxtLocator = LocatorsXPath.XPathQueryGenerator("id", "postal-code");

    public Text FirstNameTxt => new(_firstNameTxtLocator, "First Name");

    public Text LastNameTxt => new(_lastNameTxtLocator, "Last Name");

    public Text ZipCodeTxt => new(_zipCodeNameTxtLocator, "Postal Code");

    public Button NextStepBtn => new(_nextStepBtnLocator, "Next Step");
}