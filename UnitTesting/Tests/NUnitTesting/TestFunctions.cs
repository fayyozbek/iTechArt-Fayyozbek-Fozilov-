using NUnit.Allure.Core;
using NUnit.Framework;

namespace UnitTesting.Tests.NUnitTesting;

[AllureNUnit]
[TestFixture]
[FixtureLifeCycle(LifeCycle.SingleInstance)]
[NonParallelizable]
public class TestFunctions : BaseTest
{
    private static object[] _operators =
    {
        new object[] { '+', 1, 2, 3},
        new object[] { '-', 5, 4, 1},
        new object[] { '*', 3, 2, 6},
        new object[] { '/', 4, 4, 1}
    };
    
    [Category("Test of operators")]
    [Test(Description = "In this test we are checking opertors for work", Author = "Fayyozbek Fozilov")]
    [Order(2)]
    [TestCaseSource(nameof(_operators))]
    public void TestOperator(char charOperator , double firstVariable, double secondVariable, double expectedResult)
    {
        double total= Calculator.Calculations(charOperator , firstVariable, secondVariable);
        Assert.That(total, Is.EqualTo(expectedResult));
    }

    [Test]
    [Order(1)]
    public void TestPercent()
    {
        double total = Calculator.Percentage(10, 10);
        Assert.That(total, Is.EqualTo(1));
    }
}