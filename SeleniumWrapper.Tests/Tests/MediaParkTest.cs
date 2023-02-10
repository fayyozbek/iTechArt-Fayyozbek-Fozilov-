using NUnit.Allure.Core;

namespace SeleniumWrapper.Tests.Tests;

[AllureNUnit]
public class MediaParkTest : BaseTest
{
    
    [Test]
    [TestCase("Name", "LastName", "998888888", "adresss")]
    public void Test(string firstName, string lastName, string mobile, string adress)
    {
        TvCategoryPage.OpenPage();
        Assert.True(TvCategoryPage.IsPageOpened);
        
        TvCategoryPage.ClickAddToItem();
        TvCategoryPage.ClickCartBtn();
        Assert.True(TvCategoryPage.IsCartOpened);
        Assert.That(TvCategoryPage.totalCount, Does.Contain("2"));
        
        TvCategoryPage.ClickOrderBtn();
        Assert.True(OrderPage.IsPageOpened);
        
        OrderPage.FullFillInputs(firstName, lastName, mobile);
        Assert.That(OrderPage.GetInputFirstName, Is.EqualTo(firstName));
        Assert.That(OrderPage.GetInputLastName, Is.EqualTo(lastName));
        Assert.That(OrderPage.GetInputMobile, Is.EqualTo("(99) 888-88-88"));
        
        OrderPage.ClickFirstNext();
        OrderPage.FullFillAddress(adress);
        Assert.That(OrderPage.GetInputAddress, Is.EqualTo(adress));
        
        OrderPage.ClickSecondNext();
        OrderPage.CheckPaymentType();
        OrderPage.FullFillCaptcha();
        OrderPage.CheckAgreement();
        OrderPage.ClickCheckout();
        Assert.True(MessagePage.IsPageOpened);
    }
}