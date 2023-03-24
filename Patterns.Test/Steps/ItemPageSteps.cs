using NUnit.Allure.Attributes;
using Patterns.Test.Strategy.GetItemStrategy;

namespace Patterns.Test.Steps;

public class ItemPageSteps
{
    public ItemPageSteps(Browser browser)
    {
        Browser = browser;
    }

    private Browser Browser { get; }

    private IGetItemStrategy GetItemStrategy => new ItemPageStrategy(Browser);

    [AllureStep("Get actual result")]
    public ItemModel GetItem()
    {
       return GetItemStrategy.GetItem();
    }
}