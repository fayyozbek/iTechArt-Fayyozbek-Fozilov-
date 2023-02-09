using NUnit.Allure.Core;
using NUnit.Framework;

namespace SeleniumWrapper.Tests.Tests;

[AllureNUnit]
public class MediaParkTest : BaseTest
{
    
    [Test]
    public void Test()
    {
        TvCategoryPage.OpenPage();
        Assert.True(TvCategoryPage.IsPageOpened);
        
        TvCategoryPage.ClickAddToItem();
        TvCategoryPage.ClickCartBtn();
        Assert.True(TvCategoryPage.IsCartOpened);
        Assert.That(TvCategoryPage.totalCount, Is.EqualTo("2"));
    }
}