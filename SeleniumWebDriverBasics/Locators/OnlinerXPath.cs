using OpenQA.Selenium;

namespace SeleniumWebDriverBasics.Locators;

public class OnlinerXPath
{
    public static readonly By XPathToHonorTitles = By.XPath("//*[contains(@data-bind, \"product.full_name\") and contains(text(), \"HONOR\")]");
    
    public static readonly By XPathForFirstProduct = By.XPath("//div[@id=\"schema-products\"]/div[2]/div[contains(@class,\"schema-product_narrow-sizes\")]/div[contains(@class,\"schema-product__part_1\")]//label[@class=\"schema-product__control\"]");

    public static readonly By XPathForThirdProduct = By.XPath("//div[@id=\"schema-products\"]/div[5]/div[contains(@class,\"schema-product_narrow-sizes\")]/div[contains(@class,\"schema-product__part_1\")]//label[@class=\"schema-product__control\"]");

    public static readonly By XPathForUsernameInput =
        By.XPath("//*[contains(@class, \"auth-input auth-input_primary auth-input_base auth-form__input auth-form__input_width_full\") and @type=\"text\"]");

    public static readonly By XPathForPasswordInput =
        By.XPath("//*[contains(@class, \"auth-input auth-input_primary auth-input_base auth-form__input auth-form__input_width_full\") and @type=\"password\"]");
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