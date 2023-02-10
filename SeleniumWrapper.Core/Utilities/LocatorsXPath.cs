namespace SeleniumWrapper.Core.Utilities;

public static class LocatorsXPath
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
    
    public static By XPathQueryGenerator(string searchWhat, int index)
    {
        return By.XPath($"//*[contains(@class, \"{searchWhat}\")][{index}]");
    }
    
    public static By XPathQueryGenerator(string searchWhat, int index, string addtionalTag)
    {
        return By.XPath($"//*[contains(@class, \"{searchWhat}\")][{index}]//{addtionalTag}");
    }

    public static By XPathQueryUnique(string xpath)
    {
        return By.XPath(xpath);

    }
}