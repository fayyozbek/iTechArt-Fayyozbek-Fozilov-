namespace Patterns.Core.Elements;

public interface IText : IElement
{
    public void Input(string text);
    public string GetValue();
}