namespace StudyingApproachesToBuildingTests;

public class TestSwagLabsTDD
{
    [Test]
    public void TestLogin()
    {   
        //Green
        SauceDemo.OpenBrowser();
        SauceDemo.Login("standard_user", "secret_sauce");
        var element = SauceDemo.findElementWithText("Products");
        Assert.That(element.GetAttribute("value"), Is.EqualTo("Products"));
    }
    [Test]
    public void TestAddItem()
    {
        //Green
        SauceDemo.OpenBrowser();
        SauceDemo.Login("standard_user", "secret_sauce");
        var element = SauceDemo.findButton("Add");
        element.Click();
        element = SauceDemo.findByClass("shopping_cart_link");
        element.Click();
        element = SauceDemo.findByClass("cart_quantity");
        Assert.That(element.GetAttribute("value"), Is.EqualTo("1"));
    }
}

public static class SauceDemo
{
    public static void OpenBrowser()
    {
        throw new NotImplementedException();
    }

    public static void Login(string user, string password)
    {
        throw new NotImplementedException();
    }

    public static object findElementWithText(string products)
    {
        throw new NotImplementedException();
    }

    public static IWebElement findButton(string add)
    {
        throw new NotImplementedException();
    }

    public static IWebElement findByClass(string shoppingCartLink)
    {
        throw new NotImplementedException();
    }
}