namespace StudyingApproachesToBuildingTests;
[Category("Calculator")]
[Parallelizable(ParallelScope.Children)]
public class TestCalculatorTdd
{
    
    private static object[] _objects =
    {
        new object[] {  1, 2, 2},
        new object[] {  5, 4, 20},
        new object[] {  3, 2, 6},
        new object[] {  4, 4, 16}
    };
    
    [Test(Author = "Fayyobek Fozilov")]
    [TestCase(1, 2, 3)]
    [TestCase(2, 2, 4)]
    [TestCase(1, 5, 6)]
    public void TestSum(double a, double b, double expectedResult)
    {
        double total = Calculator.Sum(a, b);
        Assert.That(total, Is.EqualTo(expectedResult));
    }
    [Test]
    public void TestSubtraction()
    {
        double total = Calculator.Subtraction(5, 1);
        Assert.That(total, Is.EqualTo(4));
    }
    [Test]
    [TestCaseSource(nameof(_objects))]
    public void TestMultiplication(double a, double b, double expectedResult)
    {
        double total = Calculator.Multiplication(a, b);
        Assert.That(total, Is.EqualTo(expectedResult));
    }
    [Test]
    public void TestDivision()
    {
        double total = Calculator.Division(4, 2);
        Assert.That(total, Is.EqualTo(2));
    }
}

