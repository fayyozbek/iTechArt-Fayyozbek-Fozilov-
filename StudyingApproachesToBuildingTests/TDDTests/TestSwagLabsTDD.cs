namespace StudyingApproachesToBuildingTests;
public class TestSwagLabsTdd: BaseTest
{
   
    [Test]
    public void TestLogin()
    {   
        //Green
        OpenBrowser();
        Login("standard_user", "secret_sauce");
        var element = FindElementWithText("Products");
        Assert.That(element.GetAttribute("value"), Is.EqualTo("Products"));
    }
    [Test]
    public void TestAddItem()
    {
        //Green
        OpenBrowser();
        Login("standard_user", "secret_sauce");
        var element = FindButton("Add");
        element.Click();
        element = FindByClass("shopping_cart_link");
        element.Click();
        element = FindByClass("cart_quantity");
        Assert.That(element.GetAttribute("value"), Is.EqualTo("1"));
    }

    [Test]
    public void TestAddAndRemoveItem()
    {
        //Green
        OpenBrowser();
        Login("standard_user", "secret_sauce");
        var element = FindButton("Add");
        element.Click();
        element = FindByClass("shopping_cart_link");
        element.Click();
        element = FindByClass("cart_quantity");
        Assert.That(element.GetAttribute("value"), Is.EqualTo("1"));
        BackToPreviousPage();
        element = FindButton("Remove");
        element.Click();
        element = FindByClass("shopping_cart_link");
        element.Click();
        try
        {
            element = FindByClass("cart_quantity");
        }
        catch (NoSuchElementException e)
        {
            Assert.Pass();
        }
    }
}