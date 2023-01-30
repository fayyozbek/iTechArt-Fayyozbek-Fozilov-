namespace SeleniumWebDriver.Advanced.Part1.Pages;

public class ProgressBarPage : BasePage
{
    public ProgressBarPage(IWebDriver webDriver) : base(webDriver)
    {
    }
    
    protected override By UniqueWebLocator  => DemoqaXPath.XPathQueryGenerator("main-header");
    
    protected override string UrlPath { get; }
    
    new public  bool IsPageOpened => WebDriver.FindElement(UniqueWebLocator).Text.Equals("Progress Bar");
    
    private readonly By _startStopBtnLocator = DemoqaXPath.XPathQueryGenerator("id", "startStopButton");
    
    private readonly By _progressBarLocator = DemoqaXPath.XPathQueryGenerator("role", "progressbar");

    private IWebElement StartStopBtn => WebDriver.FindElement(_startStopBtnLocator);
    
    private IWebElement ProgressBar => WebDriver.FindElement(_progressBarLocator);

    public void ClickStartStopBtn()
    {
        StartStopBtn.Click();
    }

    public void ClickStopBtn()
    {
        WebDriverWait.PollingInterval=TimeSpan.FromMilliseconds(10);
        WebDriverWait.Until(_ => ProgressBar.Text.Contains("46"));
        StartStopBtn.Click();
    }

    public bool isProgressBar46Precent => ProgressBar.Text.Contains("46");
}