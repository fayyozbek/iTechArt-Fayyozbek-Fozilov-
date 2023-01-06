namespace UnitTesting.Tests;
[TestFixture]
[SingleThreaded]
public class TestFunctionsWithMemory : BaseTest
{
    [SetUp]
    public void Setup()
    {
        memory.memoryValue = 1;
    }

    [Test]
    [TestCase(1.00)]
    [TestCase(2.00)]
    [TestCase(3.00)]
    public void TestFunctionAddWithMemomry(double a)
    {
        double total = Calculator.Calculations('+', a, memory.memoryValue);
        double expectedResult = memory.memoryValue + total;
        memory.AddToMemory(total);
        Assert.That(memory.memoryValue, Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void TestFunctionMinusWithMemomry()
    {
        double total = Calculator.Calculations('+', 1, memory.memoryValue);
        double expectedResult = memory.memoryValue - total;
        memory.MinusFromMemory(total);
        Assert.That(memory.memoryValue, Is.EqualTo(expectedResult));
    }

    [TearDown]
    public void TearDown()
    {
        memory.ClearMemory();
    }
    
}