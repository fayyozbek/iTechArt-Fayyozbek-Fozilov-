namespace SeleniumWebDriver.Advanced.Part1.Pages;

public class FramesPage : BasePage
{
    public FramesPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator  => DemoqaXPath.XPathQueryGenerator("main-header");
    
    protected override string UrlPath { get; }
    
    new public  bool IsPageOpened => WebDriver.FindElement(UniqueWebLocator).Text.Equals("Frames");
    
    private readonly By _frameText = DemoqaXPath.XPathQueryGenerator("id", "sampleHeading");
    
    public bool IsUpperAndLowerFramesEqual
    {
        get
        {
            WebDriver.SwitchTo().Frame("frame1");
            var upperFrameText = WebDriver.FindElement(_frameText).Text;
            WebDriver.SwitchTo().DefaultContent();
            WebDriver.SwitchTo().Frame("frame2");
            var lowerFrameText = WebDriver.FindElement(_frameText).Text;
            return lowerFrameText.Equals(upperFrameText);
        }
    }
}