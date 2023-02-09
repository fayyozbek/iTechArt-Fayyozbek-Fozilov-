using OpenQA.Selenium;
using SeleniumWrapper.Core.Elements;
using SeleniumWrapper.Core.Utilities;

namespace Selenium.Lection.SimpleWrapper.Core;

public class Text : BaseElement
{
    public Text(By locator, string name) : base(locator, name)
    {
    }

    public void Input(string text)
    {
        Logger.Instance.Info($"Fill with text in {Name} element");
        FindElement().SendKeys(text);
    }

    public string GetValue()
    {
        Logger.Instance.Info($"Take value from {Name} element");
        return FindElement().GetAttribute("value");
    }
}