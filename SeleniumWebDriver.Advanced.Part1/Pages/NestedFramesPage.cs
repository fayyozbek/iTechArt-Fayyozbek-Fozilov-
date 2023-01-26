using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V109.Page;

namespace SeleniumWebDriver.Advanced.Part1.Pages;

public class NestedFramesPage : BasePage
{
    public NestedFramesPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => DemoqaXPath.XPathQueryGenerator("main-header");
    
    new public  bool IsPageOpened => WebDriver.FindElement(UniqueWebLocator).Text.Equals("Nested Frames");
    
    private readonly By _childFrameLocator = DemoqaXPath.XPathQueryGenerator("srcdoc", "Child");
    protected override string UrlPath { get; }
    
    private readonly By _frameBtnLocator = DemoqaXPath.XPathQueryGenerator("id", "item-2", "span[contains(text(),\"Frame\")]");

    private IWebElement FrameBtn => WebDriver.FindElement(_frameBtnLocator);

    public bool IsParentAndChildTextRight
    {
        get
        {
            WebDriver.SwitchTo().Frame("frame1");
            var element=WebDriver.FindElement(By.TagName("body"));
            if (element.Text.Contains("Parent"))
            {
                var childFrame = WebDriver.FindElement(_childFrameLocator);
                element = WebDriver.SwitchTo().Frame(childFrame).FindElement(By.TagName("body"));
                if (element.Text.Contains("Child"))
                {
                    WebDriver.SwitchTo().DefaultContent();
                    return true;
                }
                else
                {
                    WebDriver.SwitchTo().DefaultContent();
                    return false;
                }
            }
            else
            {
                WebDriver.SwitchTo().DefaultContent();
                return false;
            }
        }
    }

    public void ClickFrame()
    {
        ScrollToView(FrameBtn);
        FrameBtn.Click();
    }
}