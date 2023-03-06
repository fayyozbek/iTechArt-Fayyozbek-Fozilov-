using Xunit;

namespace UnitTesting.Tests.XunitTesting;

public class TestFunction
{
    private readonly ICalculator _calculator;

    public TestFunction(ICalculator calculator)
    {
        _calculator = calculator;
    }

    [Theory]
    [InlineData('+', 5, 5, 10)]
    public void TestOperator(char charOperator, double firstVariable, double secondVariable, double expectedResult)
    {
        double total= _calculator.Calculations(charOperator , firstVariable, secondVariable);
        Assert.Equal(expectedResult, total);
    }
    [Fact]
    public void TestPercent()
    {
        double total = _calculator.Percentage(10, 10);
        Assert.Equal(1, total);
    }
}