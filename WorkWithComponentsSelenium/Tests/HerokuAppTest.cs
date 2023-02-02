using WorkWithComponentsSelenium.Pages;

namespace WorkWithComponentsSelenium;

public class HerokuAppTest: BaseTest
{
    [Test]
    [TestCase("admin", "admin", "Congratulations! You must have the proper credentials.")]
    public void BasicAuthorization(string username, string password, string expectedText)
    {
        BasicAuthPage.OpenPage();
        Assert.That(BasicAuthPage.PageOpenedText, Does.Contain("basic_auth"));
       
        BasicAuthPage.EnterUsernameAndPassword(username, password);
        Assert.That(BasicAuthPage.AuthenticationPassedText, Does.Contain("Internet"));
        Assert.That(BasicAuthPage.ExpectedText, Is.EqualTo(expectedText));
    }
    
    [Test]
    [TestCase("test.jpg")]
    public void UploadImage(string nameofFile){
        UploadImagePage.OpenPage();
        Assert.True(UploadImagePage.IsPageOpened);
        
        UploadImagePage.LoadImage(nameofFile);
        Assert.That(UploadImagePage.GetExpectedText(), Does.Contain("Upload"));
        Assert.That(UploadImagePage.UploadedFilesText, Does.Contain(nameofFile));
    }

    [Test]
    public void Actions()
    {
        ActionsPage.OpenPage();
        Assert.True(ActionsPage.IsPageOpened);
        var random = new Random();
        var expectedRndNumber = random.Next(1, 9);
        ActionsPage.ChangeSlider(expectedRndNumber);
        Assert.That(ActionsPage.ExpectedNumberInSliderText, Does.Contain(((double)expectedRndNumber / 2).ToString()));
    }
    
    [Test]
    public void Windows()
    {
        WindowsPage.OpenPage();
        Assert.True(WindowsPage.IsPageOpened);
        
        WindowsPage.OpenNewWindow();
        WindowsPage.MoveToLastOrDefaultTab();
        Assert.That(NewWindowPage.UniqueWebElementText, Does.Contain("Window"));
        
        WindowsPage.MoveToTab(0);
        Assert.True(WindowsPage.IsPageOpened);
        
        WindowsPage.OpenNewWindow();
        WindowsPage.MoveToTab(1);
        Assert.That(NewWindowPage.UniqueWebElementText, Does.Contain("Window"));
        
        WindowsPage.MoveToLastOrDefaultTab();
        NewWindowPage.CloseTab();
        Assert.True(NewWindowPage.IsTabClosed(2));
        
        NewWindowPage.MoveToTab(0);
        WindowsPage.CloseTab();
        Assert.True(WindowsPage.IsTabClosed());
        
        WindowsPage.MoveToLastOrDefaultTab();
        NewWindowPage.CloseTab();
        Assert.True(NewWindowPage.IsTabClosed());
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void Hovers(int indexOfUser)
    {
        HoversPage.OpenPage();
        Assert.True(HoversPage.IsPageOpened);
        
        HoversPage.MoveToAvatar(indexOfUser);
        Assert.True(HoversPage.IsAvatarLinkAvailable(indexOfUser));
        Assert.True(HoversPage.IsAvatarUserNameRight(indexOfUser));
        
        HoversPage.ClickOnViewProfile(indexOfUser);
        Assert.That(BasePage.ExpectedUrl, Does.Contain(UsersPage.GetUrl));
        
        HoversPage.BackToPreviousPage();
        Assert.True(HoversPage.IsPageOpened);
    }

    [Test]
    public void Download()
    {
        DownloadPage.OpenPage();
        Assert.That(DownloadPage.PageOpenedText, Does.Contain("File Downloader"));
        
        DownloadPage.RandomDownloadFile();
        Assert.True(DownloadPage.IsFileExists);
    }
}