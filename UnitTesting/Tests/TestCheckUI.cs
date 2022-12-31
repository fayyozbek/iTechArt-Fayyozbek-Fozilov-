using OpenQA.Selenium;

namespace UnitTesting.Tests;

public class TestCheckUI : BaseTest
{
   // [Parallelizable(scope: ParallelScope.Default)]
    // [Test]
    //
    // public void EnterIntegerNumbers( string number)
    // {
    //     var baseUrlLikeUri = new Uri(BaseUrl, UriKind.Absolute);
    //         
    //     WebDriver.Navigate().GoToUrl(baseUrlLikeUri);
    //     WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    //
    //     var numberButton = WebDriver.FindElement(By.XPath($"//input[@type='button'][contains(@value, '{number}')]"));
    //     numberButton.Click();
    //     
    //     var enterValue = WebDriver.FindElement(By.XPath($"//input[@id='fld_1']"));
    //     Assert.That(enterValue.GetAttribute("value"), Is.EqualTo(number));
    // }
    
    [Test]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    [TestCase("0")]
    [TestCase("1.1")]
    [TestCase("2.03")]
    [TestCase("645")]
    [TestCase("6789")]
    public void TestEnterNumbers( string numbers)
    {
        OpenBrowser();
        EnterFunction(numbers);

        var enterValue = WebDriver.FindElement(By.XPath($"//input[@id='fld_1']"));
        Assert.That(enterValue.GetAttribute("value"), Is.EqualTo(numbers));
    }

    [Test]
    public void TestClearLastDigit()
    {
        OpenBrowser();
        
        EnterFunction("1234");
        
        WebDriver.FindElement(By.XPath($"//div[@title='backspace']")).Click();
        
        var enterValue = WebDriver.FindElement(By.XPath($"//input[@id='fld_1']"));
        Assert.That(enterValue.GetAttribute("value"), Is.EqualTo("123"));
    }
    
    [Test]
    public void TestClearLast()
    {
       OpenBrowser();
       EnterFunction("1234+5");
       var button = WebDriver.FindElement(By.XPath($"//input[@type='button'][contains(@onclick, 'clearLast')]"));
       button.Click();
       try
       {
           var enterValue = WebDriver.FindElement(By.XPath($"//input[@id='fld_3']"));
       }
       catch (NoSuchElementException e)
       {
           Assert.Pass();
       }
    }
    
    [Test]
    public void TestClearAll()
    {
        OpenBrowser();
        
        EnterFunction("123");
        
        WebDriver.FindElement(By.XPath($"//input[@type='button'][contains(@value, 'AC')]")).Click();
        
        var enterValue = WebDriver.FindElement(By.XPath($"//input[@id='fld_1']"));
        Assert.That(enterValue.GetAttribute("value"), Is.EqualTo("0"));
    }
    
    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}