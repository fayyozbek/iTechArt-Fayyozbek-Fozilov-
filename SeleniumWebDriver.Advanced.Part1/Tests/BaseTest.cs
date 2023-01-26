using OpenQA.Selenium;
using SeleniumWebDriver.Advanced.Part1.DriverConfiguration;
using SeleniumWebDriver.Advanced.Part1.Pages;

namespace SeleniumWebDriver.Advanced.Part1;

public class BaseTest
{
    protected IWebDriver WebDriver { get; private set; }
    
    protected HomePage HomePage { get; private set; }

    protected AlertPage AlertPage { get; private set; }
   
    protected AlertFramesWindowesPage AlertFramesWindowesPage { get; private set; }
    
    protected FramesPage FramesPage { get; private set; }

    protected NestedFramesPage NestedFramesPage { get; private set; }

    
    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        
        HomePage = new HomePage(WebDriver);
        AlertPage = new AlertPage(WebDriver);
        AlertFramesWindowesPage = new AlertFramesWindowesPage(WebDriver);
        NestedFramesPage = new NestedFramesPage(WebDriver);
        FramesPage = new FramesPage(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}