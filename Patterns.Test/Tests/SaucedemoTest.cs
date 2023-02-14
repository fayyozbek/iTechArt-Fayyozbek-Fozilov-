using NUnit.Allure.Core;
using Patterns.Test.TestData;

namespace Patterns.Test.Tests;

[AllureNUnit]
public class SaucedemoTest : BaseTest
{
    [Test(Description = "Check that item from list have same name, description and price ")]
    public void CheckItem()
    {
        HomePageSteps.Login(UserModelFactory.TestUser);
        var expectedItem = InventoryPageSteps.GetItem();
        InventoryPageSteps.GoToItemDescription();
        var actualItem = ItemPageSteps.GetItem();
        Assert.Multiple(delegate
        {
            Assert.That(expectedItem.Name, Is.EqualTo(actualItem.Name));
            Assert.That(expectedItem.Description, Is.EqualTo(actualItem.Description));
            Assert.That(expectedItem.Price, Is.EqualTo(actualItem.Price));
        });
    }

    [Test(Description = "Add item to the cart , check that item was added to the cart")]
    public void AddItem()
    {
        HomePageSteps.Login(UserModelFactory.TestUser);
    }



}