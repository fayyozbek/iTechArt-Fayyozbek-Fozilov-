namespace Patterns.Core.Elements;

internal class CheckBox : BaseElement, ICheckBox
{
    public CheckBox(By locator, string name) : base(locator, name)
    {
    }

    public bool IsChecked()
    {
        return FindElement().Selected;
    }
}