using OpenQA.Selenium;
using SeleniumWrapper.Core.Elements;

namespace Selenium.Lection.SimpleWrapper.Core;

public class Button : BaseElement
{
    public Button(By locator, string name) : base(locator, name)
    {
    }
}