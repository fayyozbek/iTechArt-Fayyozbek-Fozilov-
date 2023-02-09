using OpenQA.Selenium;
using SeleniumWrapper.Core.Elements;

namespace Selenium.Lection.SimpleWrapper.Core;

public class CheckBox : BaseElement
{
    public CheckBox(By locator, string name) : base(locator, name)
    {
    }

    public bool IsChecked()
    {
        return FindElement().Selected;
    }
}