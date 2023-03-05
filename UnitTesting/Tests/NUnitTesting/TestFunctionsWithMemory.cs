using NUnit.Allure.Core;
using NUnit.Framework;

namespace UnitTesting.Tests.NUnitTesting;

[AllureNUnit]
[TestFixture]
[SingleThreaded]
public class TestFunctionsWithMemory : BaseTest
{
    [SetUp]
    public void Setup()
    {
        memory.MemoryValue = 1;
    }

    [Test]
    [TestCase(1.00)]
    [TestCase(2.00)]
    [TestCase(3.00)]
    public void TestFunctionAddWithMemory(double a)
    {
        double total = Calculator.Calculations('+', a, memory.MemoryValue);
        double expectedResult = memory.MemoryValue + total;
        memory.AddToMemory(total);
        Assert.That(memory.MemoryValue, Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void TestFunctionMinusWithMemory()
    {
        double total = Calculator.Calculations('+', 1, memory.MemoryValue);
        double expectedResult = memory.MemoryValue - total;
        memory.MinusFromMemory(total);
        Assert.That(memory.MemoryValue, Is.EqualTo(expectedResult));
    }

    [TearDown]
    public void TearDown()
    {
        memory.ClearMemory();
    }
}