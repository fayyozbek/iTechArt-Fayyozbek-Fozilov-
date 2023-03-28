namespace Patterns.Core.Elements;

public class ElementsBuilder :IElementsBuilder
{
    public IElement CreateLabel(By locator, string name)
    {
        return new Label(locator, name);
    }

    public IButton CreateButton(By locator, string name)
    {
        return new Button(locator, name);
    }

    public IText CreateText(By locator, string name)
    {
        return new Text(locator, name);
    }

    public ICheckBox CreateCheckBox(By locator, string name)
    {
        return new CheckBox(locator, name);
    }
}