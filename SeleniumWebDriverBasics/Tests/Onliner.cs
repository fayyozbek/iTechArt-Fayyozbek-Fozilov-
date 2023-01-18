using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriverBasics.DriverConfiguration;
using SeleniumWebDriverBasics.Utilities;
namespace SeleniumWebDriverBasics;

public class Onliner
{
    private IWebDriver _webDriver;
    [SetUp]
    public void Setup()
    {
         _webDriver = new WebDriverFactory().GetDriver();
    }

    [Test]
    public void Test()
    {
        // 1st step
        _webDriver.Navigate().GoToUrl(Configurator.BaseUrl);
        Assert.That(_webDriver.Title, Is.EqualTo("Onliner"));
        
        // 2nd step
        _webDriver.FindElement(By.XPath("//*[contains(@href, \"mobile\")]")).Click();
        var element = _webDriver.FindElement(By.XPath("//*[contains(@class, \"header_title\")]"));
        Assert.That(element.Text, Is.EqualTo("Мобильные телефоны"));
        
        // 3rd step
        element = _webDriver.FindElement(By.XPath("//*[contains(@value, \"apple\")]//parent::*"));
        ScrollToView(element);
        element.Click();
        _webDriver.FindElement(By.XPath("//*[contains(@value, \"honor\")]//parent::*")).Click();
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


        // 4th step
        element = _webDriver.FindElement(By.XPath("//*[contains(@data-bind, \"removeTag\")]//span[contains(text(), \"HONOR\")]"));
        ScrollToView(element);
        element.Click();
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        try
        {
            element = _webDriver.FindElement(By.XPath("//*[contains(@data-bind, \"product.full_name\") and contains(text(), \"Honor\")]"));
        }
        catch (NoSuchElementException)
        {
            Assert.IsTrue(true);
        }

        // 5th step
        //TODO Find relative way to element
        WebDriverWait wait = new(_webDriver, TimeSpan.FromSeconds(15));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
            By.XPath(
                "/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[2]/div/div[1]/div[1]")));
        _webDriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[2]/div/div[1]/div[1]")).Click();
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
            By.XPath(
                "/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[5]/div/div[1]/div[1]")));
        _webDriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[5]/div/div[1]/div[1]")).Click();
        var elements =
            _webDriver.FindElements(
                By.XPath("//*[contains(@data-bind, \"product.full_name\") and contains(text(), \"Apple\")]"));
        var expectedResult1 = elements[0].Text;
        var expectedResult2 = elements[2].Text;
        _webDriver.FindElement(By.XPath("//a[contains(@class, \"compare-button__sub_main\")]")).Click();
       

        // 6th step

        // 7th step

        // 8th step

        // 9th step
    }

    // [TearDown]
    // public void Teardown()
    // {
    //     _webDriver.Quit();
    // }
    
   public void ScrollToView(IWebElement element)
    {
        if (element.Location.Y > 200)
        {
            var js = $"window.scrollTo({0}, {element.Location.Y-100})";
            IJavaScriptExecutor scriptExecutor= _webDriver as IJavaScriptExecutor;
            scriptExecutor.ExecuteScript(js);
        }
    }
}