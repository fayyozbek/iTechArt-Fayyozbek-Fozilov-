using OpenQA.Selenium;

namespace SeleniumWrapper.Tests.Pages;

public class OrderPage: BasePage
{
    public OrderPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator =>LocatorsXPath.XPathQueryUnique("//*[@class=\"header_title\"]//h1[contains(text(),\"Оформить заказ\")]");
    
    private readonly By _inputFirstNameLocator=LocatorsXPath.XPathQueryGenerator("id","msordersform-first_name");
    
    private readonly By _inputLastNameLocator= LocatorsXPath.XPathQueryGenerator("id","msordersform-last_name");
    
    private readonly By _inputMobileLocator= LocatorsXPath.XPathQueryGenerator("id","msordersform-phone_m");
    
    private readonly By _inputAddressLocator= LocatorsXPath.XPathQueryGenerator("id", "msordersform-address");

    private readonly By _checkBoxDeliveryTypeLocator= LocatorsXPath.XPathQueryGenerator("id","msordersform-delivery_type");
    
    private readonly By _checkBoxPaymentTypeLocator= LocatorsXPath.XPathQueryGenerator("for","payment_info_0");

    private readonly By _checkBoxAgreementLocator= LocatorsXPath.XPathQueryGenerator("id","msordersform-offer");
    
    private readonly By _nextFirstStepLocator = LocatorsXPath.XPathQueryGenerator("template_btn");
    
    private readonly By _nextSecondStepLocator = LocatorsXPath.XPathQueryGenerator("data-csb","payment");

    private readonly By _checkOutBtnLocator = LocatorsXPath.XPathQueryGenerator("checkout-submit");
    
    private readonly By _captchaPassIndicatorLocator = LocatorsXPath.XPathQueryGenerator("captchacode has-success");


    private Text InputFirstName => new(_inputFirstNameLocator, "FirstName input");
    private Text InputLastName=> new(_inputLastNameLocator, "Last name input");
    private Text InputMobile=> new(_inputMobileLocator, "Mobile input");

    private Text InputAddress=> new(_inputAddressLocator, "Address input");

    private Button NextFirstStepBtn => new(_nextFirstStepLocator, "Next Step Button");
    
    private Button NextSecondStepBtn => new(_nextSecondStepLocator, "Next Step Button");

    private Button CheckOutBtn => new(_checkOutBtnLocator, "Check out Button");

    private CheckBox DeliveryTypeCheckBox => new(_checkBoxDeliveryTypeLocator, "Delevery type");
    
    private CheckBox PaymentTypeCheckBox => new(_checkBoxPaymentTypeLocator, "Payment type");

    private CheckBox AgreementCheckBox => new(_checkBoxAgreementLocator, "Agreement");

    private Label CaptchaPassIndicator => new(_captchaPassIndicatorLocator, "Captcha Indicator");
    
    protected override string UrlPath { get; }

    public void FullFillInputs(string firstName, string lastName, string mobile)
    {
        InputFirstName.Input(firstName);
        InputLastName.Input(lastName);
        InputMobile.Input(mobile);
        BrowserService.Browser.BrowserWait.Until(_=>InputFirstName.GetValue().Contains(firstName));
    }

    public void FullFillAddress(string address)
    {
        InputAddress.Input(address);
        BrowserService.Browser.BrowserWait.Until(_=>InputAddress.GetValue().Contains(address));
        DeliveryTypeCheckBox.Click();
    }

    public void ClickFirstNext()
    {
        NextFirstStepBtn.Click();
    }
    
    public void ClickSecondNext()
    {
        NextSecondStepBtn.ScrollToView();
        NextSecondStepBtn.Click();
    }

    public void CheckPaymentType()
    {
        ScrollToUp();
        PaymentTypeCheckBox.Click();
    }

    public void CheckAgreement()
    {
        if (!AgreementCheckBox.IsChecked())
        {
            AgreementCheckBox.Click();
        }
    }

    public void  FullFillCaptcha()
    {
        BrowserService.Browser.BrowserWait.Until(_ => CaptchaPassIndicator.IsDisplayed());
    }

    public void ClickCheckout()
    {
        CheckOutBtn.Click();
    }
    public string GetInputFirstName => InputFirstName.GetValue();
    
    public string GetInputLastName => InputLastName.GetValue();
    
    public string GetInputMobile => InputMobile.GetValue();

    public string GetInputAddress => InputAddress.GetValue();
}