using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTesting.Utils;

namespace UnitTesting.Tests;

public class BaseTest
{
    protected IWebDriver WebDriver { get; set; }
    
    protected readonly string BaseUrl = Configurator.BaseUrl;
    [SetUp]
    public void Setup()
    {
        WebDriver = new ChromeDriver();
    }

    protected void OpenBrowser()
    {
        var baseUrlLikeUri = new Uri(BaseUrl, UriKind.Absolute);
            
        WebDriver.Navigate().GoToUrl(baseUrlLikeUri);
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    protected void EnterFunction(string strNumber)
    {
        IWebElement button;
        var numberList = strNumber.ToCharArray();
        foreach (var number in numberList)
        {
            button = WebDriver.FindElement(By.XPath($"//input[@type='button'][@value='{number}']"));
            button.Click();
        }
    }
}