namespace Patterns.Core.Elements;

internal class Text : BaseElement, IText
{
    public Text(By locator, string name) : base(locator, name)
    {
    }

    public void Input(string text)
    {
        Logger.Instance.Info($"Fill with text in {((IElement)this).Name} element");
        FindElement().SendKeys(text);
    }

    public string GetValue()
    {
        Logger.Instance.Info($"Take value from {((IElement)this).Name} element");
        return FindElement().GetAttribute("value");
    }
}