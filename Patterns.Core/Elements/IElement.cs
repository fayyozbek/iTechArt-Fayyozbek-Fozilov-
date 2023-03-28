namespace Patterns.Core.Elements;

public interface IElement
{
    protected internal string Name { get; set; }
    protected internal By Locator { get; set; }
    
    public bool IsDisplayed();
    public void Click();
    public string GetText();
    
}