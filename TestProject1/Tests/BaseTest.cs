using OpenQA.Selenium;
using SeleniumWebDriverBasics.DriverConfiguration;
using SeleniumWebDriverBasics.Pages;

namespace SeleniumWebDriverBasics;

public class BaseTest
{
    protected IWebDriver WebDriver { get; private set; }
    
    protected HomePage HomePage { get; private set; }
    
    protected MobilePage MobilePage { get; private set; }
    
    protected ComparePage ComparePage { get; private set; }
    
    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        
        HomePage = new HomePage(WebDriver);
        MobilePage = new MobilePage(WebDriver);
        ComparePage = new ComparePage(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}