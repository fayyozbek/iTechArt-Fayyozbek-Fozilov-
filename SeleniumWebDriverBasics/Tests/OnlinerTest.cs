using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace SeleniumWebDriverBasics;

[AllureNUnit]
public class OnlinerTest : BaseTest
{
    [Test]
    [TestCase("Краткая информация об отличиях товара от конкурентных моделей и аналогов, сведения о позиционировании на рынке, преемственности и др.", 2)]
    [AllureTag("Regression")]
    [AllureOwner("Fayyozbek Fozilov")]
    public void Test(string expectedText, int expectedQuantity)
    {
        // 1st step
        // Open home page
        HomePage.OpenPage();
        
        // Validate that home page is opened
        Assert.True(HomePage.IsPageOpened, " Home page opened");
        
        // 2nd step
        // Click on the button mobile phones
        HomePage.ClickMobilePhoneLink();
        
        //Validate that mobile page is opened
        Assert.True(MobilePage.IsPageOpened, " Mobile page opened");
        
        // 3rd step
        MobilePage.ClickOnCheckBoxes();
        
        // 4th step
        // Remove honor from the filter
        MobilePage.ClickHonorRemoveTag();

        // Validate that no more honor phones in the title
        Assert.True(MobilePage.IsAviableHonorTitles, "Honor phones is not in the list");
       

        // 5th step
        // Click on the first and third element
        MobilePage.ClickFirstAndThirdProduct();
        
        // Validate that two items added to compare 
        Assert.That(MobilePage.QuantityOfItemsAdded, Does.Contain(expectedQuantity.ToString()), "Products added in compare list");
        
        // 6th step
        // Click on the compare button 
        MobilePage.ClickOnCompareButton();
        
        // Validate that we are on compare page
        Assert.True(ComparePage.IsPageOpened, "Compare Page is opened");

        // 7th step
        ComparePage.ClickOnDescriptionButton();
        Assert.True(ComparePage.IsDecriptionOpened, "Description box is opened");      
        
        // 8th step
        Assert.That(ComparePage.DescriptionDataTipText, Does.Contain(expectedText), "Text in description box is right");
        
        // 9th step
        ComparePage.BackPage();
        Assert.True(MobilePage.IsPageOpened, "You returned to previous page");
    }
}