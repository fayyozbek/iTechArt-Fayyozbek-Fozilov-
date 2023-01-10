using TechTalk.SpecFlow;

namespace StudyingApproachesToBuildingTests;

[Binding]
public class  SwagLabsFunctionsSteps
{
    private IWebDriver _webDriver { get; set; }
    private IWebElement _element;
    [Given(@"I go to website https://www\.saucedemo\.com")]
    public void GivenIGoToWebsiteHttpsWwwSaucedemoCom()
    {
        _webDriver = new ChromeDriver();
        _webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        
    }

    [Given(@"I fill in form username as standard_user")]
    public void GivenIFillInFormUsernameAsStandardUser()
    {
        _webDriver.FindElement(By.Id("user-name")).SendKeys("standard_user");
    }

    [Given(@"I fill in form password as secret_sauce")]
    public void GivenIFillInFormPasswordAsSecretSauce()
    {
        _webDriver.FindElement(By.Id("password")).SendKeys("secret_sauce");
    }

    [Given(@"I click on button login")]
    public void GivenIClickOnButtonLogin()
    {
        _webDriver.FindElement(By.Id("login-button")).Click();
    }

    [When(@"I login to website")]
    public void WhenILoginToWebsite()
    {
        _element =_webDriver.FindElement(By.XPath($"//span[text()='Products']"));
    }

    [Then(@"I see label products")]
    public void ThenISeeLabelProducts()
    {
        Assert.That(_element.Text, Is.EqualTo("PRODUCTS"));
    }

    [Given(@"I click on button add to cart")]
    public void GivenIClickOnButtonAddToCart()
    {
        _webDriver.FindElement(By.XPath($"//button[contains(text(),'Add')]")).Click();
    }

    [When(@"I go to cart")]
    public void WhenIGoToCart()
    {
        _webDriver.FindElement(By.ClassName("shopping_cart_link")).Click();
    }

    [Then(@"I see one item added to cart")]
    public void ThenISeeOneItemAddedToCart()
    {
        _element= _webDriver.FindElement(By.ClassName("cart_quantity"));
        Assert.That(_element.Text, Is.EqualTo("1"));
    }

    [When(@"I click on button remove")]
    public void WhenIClickOnButtonRemove()
    {
        _webDriver.FindElement(By.XPath($"//button[contains(text(),'Remove')]")).Click();
    }

    [Then(@"I see empty cart")]
    public void ThenISeeEmptyCart()
    {
        try
        {
            _element = _webDriver.FindElement(By.ClassName("cart_quantity"));
        }
        catch (NoSuchElementException e)
        {
            Assert.Pass();
        }
    }

    [TearDown]
    public void Teardown()
    {
        _webDriver.Quit();
    }
}