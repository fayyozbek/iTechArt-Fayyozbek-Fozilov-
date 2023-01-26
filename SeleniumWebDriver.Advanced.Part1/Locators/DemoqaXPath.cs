using OpenQA.Selenium;

namespace SeleniumWebDriver.Advanced.Part1.Locators;

public class DemoqaXPath
{
    public static By XPathQueryGenerator(string attribute, string searchWhat)
    {
        return By.XPath($"//*[contains(@{attribute}, \"{searchWhat}\")]");
    }
    
    public static By XPathQueryGenerator(string attribute, string searchWhat, string addtionalTag)
    {
        return By.XPath($"//*[contains(@{attribute}, \"{searchWhat}\")]//{addtionalTag}");
    }

    public static By XPathQueryGenerator(string searchWhat)
    {
        return By.XPath($"//*[contains(@class, \"{searchWhat}\")]");
    }
}