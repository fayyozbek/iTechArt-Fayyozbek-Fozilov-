using System.Runtime.Serialization;

namespace SeleniumWebDriverBasics.Resources;

public class OnlinerXPath
{
    public static readonly string XPathToHonorTitles = "//*[contains(@data-bind, \"product.full_name\") and contains(text(), \"HONOR\")]";
    public static readonly string XPathForFirstProduct ="/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[2]/div/div[1]/div[1]";
    public static readonly string XPathForSecondProduct = "/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[5]/div/div[1]/div[1]";
    public static string XPathQueryGenerator(string attribute, string searchWhat)
    {
        return $"//*[contains(@{attribute}, \"{searchWhat}\")]";
    }
    
    public static string XPathQueryGenerator(string attribute, string searchWhat, string addtionalTag)
    {
        return $"//*[contains(@{attribute}, \"{searchWhat}\")]//{addtionalTag}";
    }

    public static string XPathQueryGenerator(string searchWhat)
    {
        return $"//*[contains(@class, \"{searchWhat}\")]";
    }
    
}