using TechTalk.SpecFlow;

namespace StudyingApproachesToBuildingTests;

[Binding]
public class CalculatorFunctionsSteps
{
    [Given(@"I start calculator")]
    public void GivenIStartCalculator()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"I have the first number (.*)")]
    public void GivenIHaveTheFirstNumber(int p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"I have the second number (.*)")]
    public void GivenIHaveTheSecondNumber(int p0)
    {
        ScenarioContext.StepIsPending();
    }
    
    [When(@"I want to multiply this numbers")]
    public void WhenIWantToMultiplyThisNumbers()
    {
        ScenarioContext.StepIsPending();
    }
    
    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(int p0)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"I want to sum this numbers")]
    public void WhenIWantToSumThisNumbers()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"I want to subtraction this numbers")]
    public void WhenIWantToSubtractionThisNumbers()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"I want to divide this numbers")]
    public void WhenIWantToDivideThisNumbers()
    {
        ScenarioContext.StepIsPending();
    }
}
