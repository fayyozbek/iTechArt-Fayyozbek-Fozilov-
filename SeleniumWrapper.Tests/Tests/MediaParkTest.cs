using NUnit.Allure.Core;

namespace SeleniumWrapper.Tests.Tests;

[AllureNUnit]
public class MediaParkTest : BaseTest
{
    
    [Test]
    [TestCase("Name", "LastName", "998888888", "addresss")]
    public void Test(string firstName, string lastName, string mobile, string address)
    {
        TvCategoryPage.OpenPage();
        Assert.True(TvCategoryPage.IsPageOpened);
        
        TvCategoryPage.ClickAddToItem();
        TvCategoryPage.ClickCartBtn();
        Assert.Multiple(() =>
        {
            Assert.True(TvCategoryPage.IsCartOpened);
            Assert.That(TvCategoryPage.TotalCount, Does.Contain("2"));
        });
        TvCategoryPage.ClickOrderBtn();
        Assert.True(OrderPage.IsPageOpened);
        
        OrderPage.FullFillInputs(firstName, lastName, mobile);
        Assert.Multiple(() =>
        {
            Assert.That(OrderPage.GetInputFirstName, Is.EqualTo(firstName));
            Assert.That(OrderPage.GetInputLastName, Is.EqualTo(lastName));
            Assert.That(OrderPage.GetInputMobile, Is.EqualTo("(99) 888-88-88"));
        });
        OrderPage.ClickFirstNext();
        OrderPage.FullFillAddress(address);
        Assert.That(OrderPage.GetInputAddress, Is.EqualTo(address));
        
        OrderPage.ClickSecondNext();
        OrderPage.CheckPaymentType();
        OrderPage.FullFillCaptcha();
        OrderPage.CheckAgreement();
        OrderPage.ClickCheckout();
        Assert.True(MessagePage.IsPageOpened);
    }
}