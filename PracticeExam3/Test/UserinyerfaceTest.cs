using PracticeExam3.Pages;

namespace PracticeExam3.Test;

public class UserinyerfaceTest : BaseTest
{
    [Test]
    public void Task1()
    {
        HomePage.OpenPage();
        Assert.True(HomePage.IsPageOpened);
        
        HomePage.ClickOnStartLink();
        Assert.True(GamePage.IsPageOpened);
        
        GamePage.SendRndKeysToInputs();
        GamePage.SelectDropdown();
        GamePage.SelectCheckBox();
        GamePage.ClickNextButton();
        Assert.That(GamePage.GetPageIndicator, Does.Contain("2"));
    }

    [Test]
    public void Task2()
    {
        GamePage.OpenPage();
        Assert.True(GamePage.IsPageOpened);
        
        GamePage.ClickAcceptCoockie();
        Assert.True(GamePage.IsCookeLabel);
    }

    [Test]
    public void Task3()
    {
        GamePage.OpenPage();
        Assert.That(GamePage.GetTime, Is.EqualTo("00:00:00"));
    }

    [Test]
    public void Task4()
    {
        GamePage.OpenPage();
        Assert.True(GamePage.IsPageOpened);
        
        GamePage.ClickSendToBottomBtn();
        Assert.That(GamePage.GetClassOfHelper, Does.Contain("is-hidden"));
    }
}