namespace Patterns.Test.Components;

public class CheckoutPageComponents : BaseComponents
{
    private readonly By _firstNameTxtLocator = LocatorsXPath.XPathQueryGenerator("id", "first-name");

    private readonly By _lastNameTxtLocator = LocatorsXPath.XPathQueryGenerator("id", "last-name");

    private readonly By _nextStepBtnLocator = LocatorsXPath.XPathQueryGenerator("btn_action");

    private readonly By _zipCodeNameTxtLocator = LocatorsXPath.XPathQueryGenerator("id", "postal-code");

    public IText FirstNameTxt => Builder.CreateText(_firstNameTxtLocator, "First Name");

    public IText LastNameTxt => Builder.CreateText(_lastNameTxtLocator, "Last Name");

    public IText ZipCodeTxt => Builder.CreateText(_zipCodeNameTxtLocator, "Postal Code");

    public IButton NextStepBtn => Builder.CreateButton(_nextStepBtnLocator, "Next Step");
}