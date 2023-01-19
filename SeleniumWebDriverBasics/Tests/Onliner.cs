using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriverBasics.DriverConfiguration;
using SeleniumWebDriverBasics.Utilities;
using SeleniumExtras.WaitHelpers;
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
        WebDriverWait wait = new(_webDriver, TimeSpan.FromSeconds(5));
        const string firstProduct ="/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[2]/div/div[1]/div[1]";
        const string secondProduct = "/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[5]/div/div[1]/div[1]";
        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(firstProduct)));
        _webDriver.FindElement(By.XPath(firstProduct)).Click();
        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(secondProduct)));
        _webDriver.FindElement(By.XPath(secondProduct)).Click();
        element = _webDriver.FindElement(By.XPath("//a[contains(@class, \"compare-button__sub_main\")]//span"));
        Assert.That(element.Text, Does.Contain("2"));

        // 6th step
        _webDriver.FindElement(By.XPath("//a[contains(@class, \"compare-button__sub_main\")]")).Click();
        Assert.That(_webDriver.Title, Does.Contain("Сравнить"));
        
        // 7th step
        element = _webDriver.FindElement(By.XPath("//*[contains(@data-tip-term , \"Описание\")]"));
        element.Click();
        Assert.That(element.GetAttribute("class"), Does.Contain("trigger_visible"));

        // 8th step
        var expectedResult = "Краткая информация об отличиях товара от конкурентных моделей и аналогов, сведения о позиционировании на рынке, преемственности и др.";
        Assert.That(element.GetAttribute("data-tip-text"), Does.Contain(expectedResult));

        // 9th step
        _webDriver.Navigate().Back();
        Assert.That(_webDriver.Title, Does.Contain("Мобильные телефоны Apple"));
    }

    [TearDown]
    public void Teardown()
    {
        _webDriver.Quit();
    }
    
   public void ScrollToView(IWebElement element)
    {
        if (element.Location.Y > 200)
        {
            var js = $"window.scrollTo({0}, {element.Location.Y-80})";
            IJavaScriptExecutor scriptExecutor= _webDriver as IJavaScriptExecutor;
            scriptExecutor.ExecuteScript(js);
        }
    }
}