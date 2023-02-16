using NUnit.Allure.Core;
using Patterns.Test.TestData;

namespace Patterns.Test.Tests;

[AllureNUnit]
public class SaucedemoTest : BaseTest
{
    [Test(Description = "Check that item from list have same name, description and price ")]
    public void CheckItem()
    {
        var expectedItem =HomePageSteps
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
    public void CheckoutItem()
    {
        var isPass= HomePageSteps
            .Login(UserModelFactory.TestUser)
            .GoToCart()
            .GoToNextStep()
            .InputUserInfo(UserModelFactory.TestUser)
            .GoToNextStep()
            .GoToNextStep()
            .IsCompleteCheckout;
        Assert.True(isPass);
    }

    [Test(Description = "Login and Logout test")]
    public void LoginAndLogout()
    {
        var isPass = HomePageSteps
            .Login(UserModelFactory.TestUser)
            .Logout();
        Assert.True(isPass);
    }



}