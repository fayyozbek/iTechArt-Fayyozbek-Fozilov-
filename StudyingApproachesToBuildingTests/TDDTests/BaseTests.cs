namespace StudyingApproachesToBuildingTests;
[SetUpFixture]
public abstract class BaseTest
{
    protected IWebDriver _webDriver { get; set; }

    [SetUp]
    public void Setup()
    {
        _webDriver = new ChromeDriver();
    }
    public void OpenBrowser()
    {
        _webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    public void Login(string user, string password)
    {
        _webDriver.FindElement(By.Id("user-name")).SendKeys(user);
        _webDriver.FindElement(By.Id("password")).SendKeys(password);
        _webDriver.FindElement(By.Id("login-button")).Click();
    }

    public IWebElement FindElementWithText(string products)
    {
       return _webDriver.FindElement(By.XPath($"//span[text()='{products}']"));
    }

    public  IWebElement FindButton(string add)
    {
        return _webDriver.FindElement(By.XPath($"//button[contains(text(),'{add}')]"));
    }

    public  IWebElement FindByClass(string shoppingCartLink)
    {
        return _webDriver.FindElement(By.ClassName(shoppingCartLink));
    }

    public  void BackToPreviousPage()
    {
        _webDriver.Navigate().Back();
    }

    [TearDown]
    public void Teardown()
    {
        _webDriver.Quit();
    }
}