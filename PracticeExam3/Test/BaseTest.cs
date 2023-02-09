using OpenQA.Selenium;
using PracticeExam3.DriverConfiguration;
using PracticeExam3.Pages;

namespace PracticeExam3.Test;

public class BaseTest
{
    protected IWebDriver WebDriver { get; private set; }

    protected HomePage HomePage { get; private set; }

    protected GamePage GamePage { get; private set; }

    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        
        HomePage = new HomePage(WebDriver);
        GamePage = new GamePage(WebDriver);
    }
    
    // [TearDown]
    // public void TearDown()
    // {
    //     WebDriver.Quit();
    // }
}