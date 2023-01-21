using System.Runtime.Serialization;
using OpenQA.Selenium;

namespace SeleniumWebDriverBasics.Locators;

public class OnlinerXPath
{
    public static readonly By XPathToHonorTitles = By.XPath("//*[contains(@data-bind, \"product.full_name\") and contains(text(), \"HONOR\")]");
    
    public static readonly By XPathForFirstProduct =By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[2]/div/div[1]/div[1]");
    
    public static readonly By XPathForSecondProduct = By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[5]/div/div[1]/div[1]");
   
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