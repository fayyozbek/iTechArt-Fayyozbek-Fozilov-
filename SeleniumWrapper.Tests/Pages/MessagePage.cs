using OpenQA.Selenium;

namespace SeleniumWrapper.Tests.Pages;

public class MessagePage : BasePage
{
    public MessagePage(Browser browser) : base(browser)
    {
    }

    protected override string UrlPath { get; }

    protected override By UniqueWebLocator => LocatorsXPath.XPathQueryGenerator("alert-success");
    
}