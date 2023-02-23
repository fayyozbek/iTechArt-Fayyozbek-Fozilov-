using System.Linq.Expressions;
using NUnit.Allure.Core;
using Patterns.Test.TestData;

namespace Patterns.Test.Tests;

[AllureNUnit]
public class SaucedemoTest : BaseTest
{
    [Test(Description = "Check that item from list have same name, description and price ")]
    public void CheckItemTest()
    {
        var expectedItem = HomePageSteps
            .Login(UserModelFactory.TestUser)
            .GetItem();
        InventoryPageSteps.GoToItemDescription();
        var actualItem = ItemPageSteps.GetItem();
        Assert.Multiple(delegate
        {
            Assert.That(expectedItem.Name, Is.EqualTo(actualItem.Name));
            Assert.That(expectedItem.Description, Is.EqualTo(actualItem.Description));
            Assert.That(expectedItem.Price, Does.Contain(actualItem.Price));
        });
    }

    [Test(Description = "Add item to the cart and checkout")]
    public void CheckoutItemTest()
    {
        var isPass = HomePageSteps
            .Login(UserModelFactory.TestUser)
            .GoToCart()
            .GoToNextStep()
            .InputUserInfo(UserModelFactory.TestUser)
            .GoToNextStep()
            .GoToNextStep()
            .IsCompleteCheckout;
        Assert.True(isPass);
    }
    
    [Test(Description = "Fail")]
    public void FailTest()
    {
        var isPass = HomePageSteps
            .Login(UserModelFactory.TestUser)
            .GoToCart()
            .GoToNextStep()
            .InputUserInfo(UserModelFactory.TestUser)
            .GoToNextStep()
            .GoToNextStep()
            .IsCompleteCheckout;
        isPass = false;
        throw new NotImplementedException();
        Assert.True(isPass);
    }

    [Test(Description = "Login and Logout test")]
    public void LoginAndLogoutTest()
    {
        var isPass = HomePageSteps
            .Login(UserModelFactory.TestUser)
            .Logout();
        Assert.True(isPass);
    }

    [Test(Description = "Add item to cart and remove item from the cart")]
    public void AddRemoveTest()
    {
        var isRemoved = HomePageSteps
            .Login(UserModelFactory.TestUser)
            .GoToCart()
            .IsRemovedItem();
        Assert.True(isRemoved);
    }

    [Test(Description = "Check that clicked item added in cart")]
    public void AddItemAndCheckTest()
    {
        var expectedItem = HomePageSteps
            .Login(UserModelFactory.TestUser)
            .GetItem();
        InventoryPageSteps.GoToCart();
        var actualItem = CartPageSteps.GetItem();
        Assert.Multiple(delegate
        {
            Assert.That(actualItem.Name, Is.EqualTo(expectedItem.Name));
            Assert.That(actualItem.Description, Is.EqualTo(expectedItem.Description));
            Assert.That(actualItem.Price, Does.Contain(expectedItem.Price));
        });
    }
}