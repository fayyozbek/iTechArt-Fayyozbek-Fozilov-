namespace UnitTesting.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Children)]
public class TestMemory: BaseTest
{
    [Test]
    public void TestMemoryAdd()
    {
        double total=  Calculator.Calculations('+', 1, 2);
        memory.AddToMemory(total);
        Assert.That(memory.memoryValue, Is.EqualTo(total));
    }
    
    [Test]
    [Retry(2)]
    public void TestMemoryMinus()
    {
        double total= Calculator.Calculations('+', 1, 1);
        double checkMemory = memory.memoryValue - total;
        memory.MinusFromMemory(total);
        Assert.That(memory.memoryValue, Is.EqualTo(checkMemory));
    }
    
    [Test]
    [Ignore("i am that it's work")]
    public void TestMemoryClear()
    {
        memory.ClearMemory();
        Assert.That(memory.memoryValue, Is.EqualTo(0));
    }
}