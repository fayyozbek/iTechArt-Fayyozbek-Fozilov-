namespace WorkWithComponentsSelenium.Pages;

public class HoversPage : BasePage
{
    public HoversPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => HerokuAppXpath.XPathQueryGenerator("figure");
    
    protected override string UrlPath => "/hovers";

    private IWebElement GetAvatarLinkByIndex(int indexOfAvatar)
    {
        By avatarLinkLocator = HerokuAppXpath.XPathQueryGenerator("figure", indexOfAvatar, "div//a");
        return WebDriver.FindElement(avatarLinkLocator);
    }
    
    private IWebElement GetAvatarUserNameByIndex(int indexOfAvatar)
    {
        By avatarLinkLocator = HerokuAppXpath.XPathQueryGenerator("figure", indexOfAvatar, "div//h5");
        return WebDriver.FindElement(avatarLinkLocator);
    }
    
    private IWebElement GetAvatarByIndex(int indexOfAvatar)
    {
        By avatarLocator = HerokuAppXpath.XPathQueryGenerator("figure", indexOfAvatar);
        return WebDriver.FindElement(avatarLocator);
    }

    public void MoveToAvatar(int indexOfAvatar)
    {
        ActionBuilder.MoveToElement(GetAvatarByIndex(indexOfAvatar)).Build().Perform();
    }

    public bool IsAvatarUserNameRight(int indexOfAvatar)
    {
        return GetAvatarUserNameByIndex(indexOfAvatar).Text.Contains($"user{indexOfAvatar}");
    }
    
    public bool IsAvatarLinkAvailable(int indexOfAvatar)
    {
        return GetAvatarLinkByIndex(indexOfAvatar).Displayed;
    }

    public void ClickOnViewProfile(int indexOfAvatar)
    {
        ExpectedUrl = GetAvatarLinkByIndex(indexOfAvatar).GetAttribute("href");
        Console.WriteLine(ExpectedUrl);
        GetAvatarLinkByIndex(indexOfAvatar).Click();
    }
}