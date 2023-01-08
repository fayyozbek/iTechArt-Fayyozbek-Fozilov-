using System.Diagnostics;

namespace StudyingApproachesToBuildingTests;

public class TestCalculatorTDD
{
    [Test]
    public void TestSum()
    {
        //RED
        double total = Calculator.Sum(1, 3);
        Assert.That(total, Is.EqualTo(4));
    }
    [Test]
    public void TestSubtraction()
    {
        //RED
        double total = Calculator.Subtraction(5, 1);
        Assert.That(total, Is.EqualTo(4));
    }
    [Test]
    public void TestMultiplication()
    {
        //RED
        double total = Calculator.Multiplication(2, 3);
        Assert.That(total, Is.EqualTo(6));
    }
    [Test]
    public void TestDivision()
    {
        //RED
        double total = Calculator.Division(4, 2);
        Assert.That(total, Is.EqualTo(2));
    }
}

