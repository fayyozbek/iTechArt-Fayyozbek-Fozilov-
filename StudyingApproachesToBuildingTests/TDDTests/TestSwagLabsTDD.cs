namespace StudyingApproachesToBuildingTests;
[TestFixture]
public class TestSwagLabsTdd: BaseTest
{
    [Test]
    [Order(1)]
    [Retry(2)]
    public void TestLogin()
    {
        OpenBrowser();
        Login("standard_user", "secret_sauce");
        var element = FindElementWithText("Products");
        Assert.That(element.Text, Is.EqualTo("PRODUCTS"));
    }
    
    [Test]
    [Ignore("not finished yet ")] 
    public void TestLogOut()
    {   
        OpenBrowser();
        Login("standard_user", "secret_sauce");
        var element = FindElementWithText("Products");
        Assert.That(element.Text, Is.EqualTo("PRODUCTS"));
    }
    [Test]
    [Order(2)]
    public void TestAddItem()
    {
        OpenBrowser();
        Login("standard_user", "secret_sauce");
        var element = FindButton("Add");
        element.Click();
        element = FindByClass("shopping_cart_link");
        element.Click();
        element = FindByClass("cart_quantity");
        Assert.That(element.Text, Is.EqualTo("1"));
    }

    [Test]
    [Order(3)]
    public void TestAddAndRemoveItem()
    {
        OpenBrowser();
        Login("standard_user", "secret_sauce");
        var element = FindButton("Add");
        element.Click();
        element = FindByClass("shopping_cart_link");
        element.Click();
        element = FindByClass("cart_quantity");
        Assert.That(element.Text, Is.EqualTo("1"));
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