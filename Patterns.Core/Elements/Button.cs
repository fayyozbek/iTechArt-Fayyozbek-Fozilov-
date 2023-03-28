namespace Patterns.Core.Elements;

internal class Button : BaseElement, IButton
{
    public Button(By locator, string name) : base(locator, name)
    {
    }
}