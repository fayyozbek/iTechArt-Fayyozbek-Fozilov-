namespace Patterns.Test.Components;

public abstract class BaseComponents
{
    protected IElementsBuilder Builder => new ElementsBuilder();
}