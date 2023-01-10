using TechTalk.SpecFlow;

namespace StudyingApproachesToBuildingTests;

[Binding]
[Category("Calculator")]
public class CalculatorFunctionsSteps
{
    private int _firstNumber;
    private int _secondNumber;
    private int _total;
    [Given(@"I have the first number (.*)")]
    public void GivenIHaveTheFirstNumber(int p0)
    {
        _firstNumber = p0;
    }

    [Given(@"I have the second number (.*)")]
    public void GivenIHaveTheSecondNumber(int p0)
    {
        _secondNumber = p0;
    }
    
    [When(@"I want to multiply this numbers")]
    public void WhenIWantToMultiplyThisNumbers()
    {
        _total = (int)Calculator.Multiplication(_firstNumber,_secondNumber);
    }
    
    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(int p0)
    {
        Assert.That(_total, Is.EqualTo(p0) );
    }

    [When(@"I want to sum this numbers")]
    public void WhenIWantToSumThisNumbers()
    {
        _total = (int)Calculator.Sum(_firstNumber,_secondNumber);
    }

    [When(@"I want to subtraction this numbers")]
    public void WhenIWantToSubtractionThisNumbers()
    {
        _total = (int)Calculator.Subtraction(_firstNumber,_secondNumber);
    }

    [When(@"I want to divide this numbers")]
    public void WhenIWantToDivideThisNumbers()
    {
        _total = (int)Calculator.Division(_firstNumber,_secondNumber);
    }
}
