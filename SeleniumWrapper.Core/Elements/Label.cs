using OpenQA.Selenium;
using SeleniumWrapper.Core.Elements;

namespace Selenium.Lection.SimpleWrapper.Core;

public class Label : BaseElement
{
    public Label(By locator, string name) : base(locator, name)
    {
    }
}