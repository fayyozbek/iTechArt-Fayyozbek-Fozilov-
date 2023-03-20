using PracticeExam.Core.Utilities;

namespace PracticeExam.Core.Elements;

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