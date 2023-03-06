using Xunit;

namespace UnitTesting.Tests.XunitTesting;

public class TestFunctionsWithMemory : IDisposable
{
    private readonly ICalculator _calculator;
    private readonly IMemory _memory;

    public TestFunctionsWithMemory(ICalculator calculator, IMemory memory)
    {
        _calculator = calculator;
        _memory = memory;
        _memory.MemoryValue = 1;
    }
    
    [Theory]
    [InlineData(1.00)]
    public void TestFunctionAddWithMemory(double a)
    {
        double total = _calculator.Calculations('+', a, _memory.MemoryValue);
        double expectedResult = _memory.MemoryValue + total;
        _memory.AddToMemory(total);
        Assert.Equal(expectedResult, _memory.MemoryValue);
    }
    
    [Fact]
    public void TestFunctionMinusWithMemory()
    {
        double total = _calculator.Calculations('+', 1, _memory.MemoryValue);
        double expectedResult = _memory.MemoryValue - total;
        _memory.MinusFromMemory(total);
        Assert.Equal(expectedResult, _memory.MemoryValue);
    }

    public void Dispose()
    {
        _memory.ClearMemory();
    }
}