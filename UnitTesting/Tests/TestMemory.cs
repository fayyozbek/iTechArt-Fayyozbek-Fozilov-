namespace UnitTesting.Tests;

public class TestMemory : BaseTest
{
    [Test]
    public void TestMemoryAdd()
    {
        OpenBrowser();
        EnterFunction("1");
        WebDriver.FindElement(By.XPath($"//input[@type='button'][@onclick='javascript:operator(\"+\")']")).Click();
        EnterFunction("2=");
        WebDriver.FindElement(By.XPath($"//input[@type='button'][@value='m+']")).Click();
        var memoryValue = WebDriver.FindElement(By.XPath($"//input[@id='memfld']"));
        Assert.That(memoryValue.GetAttribute("value"), Is.EqualTo("3"));
    }
    
    [Test]
    public void TestMemoryMinus()
    {
        OpenBrowser();
        EnterFunction("1");
        WebDriver.FindElement(By.XPath($"//input[@type='button'][@onclick='javascript:operator(\"+\")']")).Click();
        EnterFunction("2=");
        WebDriver.FindElement(By.XPath($"//input[@type='button'][@value='m+']")).Click();
        EnterFunction("1");
        WebDriver.FindElement(By.XPath($"//input[@type='button'][@value='m-']")).Click();
        var memoryValue = WebDriver.FindElement(By.XPath($"//input[@id='memfld']"));
        Assert.That(memoryValue.GetAttribute("value"), Is.EqualTo("2"));
    }
    [Test]
    public void TestMemoryClear()
    {
        OpenBrowser();
        EnterFunction("1");
        WebDriver.FindElement(By.XPath($"//input[@type='button'][@onclick='javascript:operator(\"+\")']")).Click();
        EnterFunction("2=");
        WebDriver.FindElement(By.XPath($"//input[@type='button'][@value='m+']")).Click();
        WebDriver.FindElement(By.XPath($"//input[@type='button'][@value='mc']")).Click();
        var memoryValue = WebDriver.FindElement(By.XPath($"//input[@id='memfld']"));
        Assert.That(memoryValue.GetAttribute("value"), Is.EqualTo("0"));
    }
}