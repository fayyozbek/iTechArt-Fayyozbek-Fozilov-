using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using UnitTesting.Utils;

namespace UnitTesting.Tests;

[TestFixture]
[SetUpFixture]
[Parallelizable(ParallelScope.None)]
[assembly: LevelOfParallelism(3)]
public abstract class BaseTest
{
    protected IWebDriver WebDriver { get; set; }
    protected readonly string BaseUrl = Configurator.BaseUrl;
    private string osInfo { get; set; }

    [OneTimeSetUp]
    public void GetOs()
    {
        osInfo = Environment.OSVersion.ToString();
    }
    [SetUp]
    public void Setup()
    {
       if (osInfo.Contains("Windows"))
       {
           WebDriver = new ChromeDriver();
       }
       else if (osInfo.Contains("Unix"))
       {
           WebDriver = new FirefoxDriver();
       }
       else if (osInfo.Contains("Mac"))
       {
           WebDriver = new SafariDriver();
       }
    }

    protected void OpenBrowser()
    {
        var baseUrlLikeUri = new Uri(BaseUrl, UriKind.Absolute);
        WebDriver.Navigate().GoToUrl(baseUrlLikeUri);
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    protected void EnterFunction(string strNumber)
    {
        var numberList = strNumber.ToCharArray();
        foreach (var number in numberList)
            WebDriver.FindElement(By.XPath($"//input[@type='button'][@value='{number}']")).Click();
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }

    [OneTimeTearDown]
    public void CloseAllWindows()
    {
        Process[] AllProcesses = Process.GetProcesses();
        foreach (var process in AllProcesses)
        {
            if (process.MainWindowTitle != "")
            {
                string s = process.ProcessName.ToLower();
                if (s.Contains("iexplore") || s.Contains("iexplorer") || s.Contains("chrome") || s.Contains("firefox") )
                    process.Kill();
            }
        }
        
    }
}