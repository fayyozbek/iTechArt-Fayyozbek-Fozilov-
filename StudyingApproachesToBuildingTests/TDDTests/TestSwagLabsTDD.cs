namespace StudyingApproachesToBuildingTests;

public class TestSwagLabsTdd
{
    [Test]
    public void TestLogin()
    {   
        //Green
        SauceDemo.OpenBrowser();
        SauceDemo.Login("standard_user", "secret_sauce");
        var element = SauceDemo.FindElementWithText("Products");
        Assert.That(element.GetAttribute("value"), Is.EqualTo("Products"));
    }
    [Test]
    public void TestAddItem()
    {
        //Green
        SauceDemo.OpenBrowser();
        SauceDemo.Login("standard_user", "secret_sauce");
        var element = SauceDemo.FindButton("Add");
        element.Click();
        element = SauceDemo.FindByClass("shopping_cart_link");
        element.Click();
        element = SauceDemo.FindByClass("cart_quantity");
        Assert.That(element.GetAttribute("value"), Is.EqualTo("1"));
    }

    [Test]
    public void TestAddAndRemoveItem()
    {
        //Green
        SauceDemo.OpenBrowser();
        SauceDemo.Login("standard_user", "secret_sauce");
        var element = SauceDemo.FindButton("Add");
        element.Click();
        element = SauceDemo.FindByClass("shopping_cart_link");
        element.Click();
        element = SauceDemo.FindByClass("cart_quantity");
        Assert.That(element.GetAttribute("value"), Is.EqualTo("1"));
        SauceDemo.BackToPreviousPage();
        element = SauceDemo.FindButton("Remove");
        element.Click();
        element = SauceDemo.FindByClass("shopping_cart_link");
        element.Click();
        try
        {
            element = SauceDemo.FindByClass("cart_quantity");
        }
        catch (NoSuchElementException e)
        {
            Assert.Pass();
        }
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

    public static IWebElement FindElementWithText(string products)
    {
        throw new NotImplementedException();
    }

    public static IWebElement FindButton(string add)
    {
        throw new NotImplementedException();
    }

    public static IWebElement FindByClass(string shoppingCartLink)
    {
        throw new NotImplementedException();
    }

    public static void BackToPreviousPage()
    {
        throw new NotImplementedException();
    }
}