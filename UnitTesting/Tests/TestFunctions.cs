namespace UnitTesting.Tests;
[Parallelizable(ParallelScope.Self)]
public class TestFunctions : BaseTest
{
    private static object[] _operators =
    {
        new object[] { "+", "1", "2", "3"},
        new object[] { "-", "5", "4", "1"},
        new object[] { "*", "3", "2", "6"},
        new object[] { "/", "4", "4", "1"}
    };
    
    [Category("Test of operators")]
    [Test(Description = "In this test we are checking opertors for work", Author = "Fayyozbek Fozilov")]
    [Order(3)]
    [TestCaseSource(nameof(_operators))]
    public void TestOperator(string strOperator , string firstVariable, string secondVariable, string expectedResult)
    {
        OpenBrowser();
        EnterFunction(firstVariable);
        WebDriver.FindElement(By.XPath($"//input[@type='button'][@onclick='javascript:operator(\"{strOperator}\")']")).Click();
        EnterFunction($"{secondVariable}=");
        var enterValue = WebDriver.FindElement(By.XPath($"//input[@id='fld_5']"));
        switch (strOperator)
        {
            case "+":
                Assert.That(enterValue.GetAttribute("value"), Is.EqualTo(expectedResult));
                break;
            case "-":
                Assert.That(enterValue.GetAttribute("value"), Is.EqualTo(expectedResult));
                break;
            case "/":
                Assert.That(enterValue.GetAttribute("value"), Is.EqualTo(expectedResult));
                break;
            case "*":
                Assert.That(enterValue.GetAttribute("value"), Is.EqualTo(expectedResult));
                break;
        }
    }

    [Test]
    [Order(1)]
    public void TestPercent()
    {
        OpenBrowser();
        EnterFunction("10");
        WebDriver.FindElement(By.XPath($"//input[@type='button'][@onclick='javascript:basicfunc(\"%\")']")).Click();
        EnterFunction("10=");
        var enterValue = WebDriver.FindElement(By.XPath($"//input[@id='fld_6']"));
        Assert.That(enterValue.GetAttribute("value"), Is.EqualTo("1"));
    }

    [Test]
    [Order(2)]
    public void TestSqrtFunc()
    {
        OpenBrowser();
        EnterFunction("100");
        WebDriver.FindElement(By.XPath($"//div[@id='sqrt_btn']")).Click();
        var enterValue = WebDriver.FindElement(By.XPath($"//input[@id='fld_4']"));
        Assert.That(enterValue.GetAttribute("value"), Is.EqualTo("10"));
    }
}