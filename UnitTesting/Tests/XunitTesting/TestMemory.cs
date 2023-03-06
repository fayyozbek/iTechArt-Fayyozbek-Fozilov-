using Xunit;

namespace UnitTesting.Tests.XunitTesting;

public class TestMemory
{
    private readonly ICalculator _calculator;
    private readonly IMemory _memory;

    public TestMemory(ICalculator calculator, IMemory memory)
    {
        _calculator = calculator;
        _memory = memory;
    }
    
    [Fact]
    public void TestMemoryAdd()
    {
        double total=  _calculator.Calculations('+', 1, 2);
        _memory.AddToMemory(total);
        Assert.Equal(total, _memory.MemoryValue);
    }
    
    [Fact]
    public void TestMemoryMinus()
    {
        double total=  _calculator.Calculations('+', 1, 2);
        _memory.AddToMemory(total);
        total= _calculator.Calculations('+', 1, 1);
        double checkMemory = _memory.MemoryValue - total;
        _memory.MinusFromMemory(total);
        Assert.Equal(checkMemory, _memory.MemoryValue);
    }
}