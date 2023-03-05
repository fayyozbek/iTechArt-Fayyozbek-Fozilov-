using Xunit;

namespace UnitTesting.Tests.XunitTesting;

public class TestCombinationFunctions
{
    private readonly ICalculator _calculator;

    public TestCombinationFunctions(ICalculator calculator)
    {
        _calculator = calculator;
    }
    
    [Theory]
    [InlineData('-', 5, 20, 4)]
    public void MinusSomePercentageFromNumberTest(char charOperator, double variable, double percentage,
        double expectedResult)
    {
        double result= _calculator.Calculations(charOperator , variable, _calculator.Percentage(variable,percentage));
        Assert.Equal(expectedResult, result);
    }
    
    
    [Theory]
    [InlineData('-', '/','+', 20, 5, -21)]
    public void LongCalculationTest(char mainOperator, char firstOperator, char secondOperator, double firstVariable, double secondVariable, double expectedResult)
    {
        double firstStep = _calculator.Calculations(firstOperator, firstVariable, secondVariable);
        double secondStep = _calculator.Calculations(secondOperator, firstVariable, secondVariable);
        
        double result= _calculator.Calculations(mainOperator , firstStep, secondStep);
        Assert.Equal(expectedResult, result);
    }
}