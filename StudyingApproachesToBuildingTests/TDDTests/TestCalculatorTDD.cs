namespace StudyingApproachesToBuildingTests;

public class TestCalculatorTdd
{
    [Test(Author = "Fayyobek Fozilov")]
    
    public void TestSum()
    {
        double total = Calculator.Sum(1, 3);
        Assert.That(total, Is.EqualTo(4));
    }
    [Test]
    public void TestSubtraction()
    {
        double total = Calculator.Subtraction(5, 1);
        Assert.That(total, Is.EqualTo(4));
    }
    [Test]
    public void TestMultiplication()
    {
        double total = Calculator.Multiplication(2, 3);
        Assert.That(total, Is.EqualTo(6));
    }
    [Test]
    public void TestDivision()
    {
        double total = Calculator.Division(4, 2);
        Assert.That(total, Is.EqualTo(2));
    }
}

