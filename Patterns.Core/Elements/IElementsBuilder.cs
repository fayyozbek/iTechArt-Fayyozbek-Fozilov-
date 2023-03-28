namespace Patterns.Core.Elements;

public interface IElementsBuilder
{
    public IElement CreateLabel(By locator, string name);
    public IButton CreateButton(By locator, string name);
    public IText CreateText(By locator, string name);
    public ICheckBox CreateCheckBox(By locator, string name);
}