namespace WorkWithComponentsSelenium;

public class HerokuAppTest: BaseTest
{
    [Test]
    [TestCase("admin", "admin")]
    public void BasicAuthorization(string username, string password)
    {
        BasicAuthPage.OpenPage();
        Assert.True(BasicAuthPage.IsPageOpened);
       
        BasicAuthPage.EnterUsernameAndPassword(username, password);
        Assert.True(BasicAuthPage.IsAuthenticationPassed);
        Assert.True(BasicAuthPage.IsExpectedTextAvailable);
    }
    
    [Test]
    public void UploadImage(){
        UploadImagePage.OpenPage();
        Assert.True(UploadImagePage.IsPageOpened);
        
        UploadImagePage.LoadImage();
        Assert.True(UploadImagePage.IsExpectedText);
        Assert.True(UploadImagePage.IsUploadedFiles);
    }

    [Test]
    public void Actions()
    {
        ActionsPage.OpenPage();
        Assert.True(ActionsPage.IsPageOpened);
        
        ActionsPage.ChangeSlider();
        Assert.True(ActionsPage.IsExpectedNumberInSlider);
    }
    
    [Test]
    public void Windows()
    {
        WindowsPage.OpenPage();
        Assert.True(WindowsPage.IsPageOpened);
        
        WindowsPage.OpenNewWindow();
        WindowsPage.MoveToLastOrDefaultTab();
        Assert.True(NewWindowPage.IsPageOpened);
        
        WindowsPage.MoveToTab(0);
        Assert.True(WindowsPage.IsPageOpened);
        
        WindowsPage.OpenNewWindow();
        WindowsPage.MoveToTab(1);
        Assert.True(NewWindowPage.IsPageOpened);
        
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
        Assert.True(UsersPage.IsExpectedUrlEqualToCurrentUrl);
        
        HoversPage.BackToPreviousPage();
        Assert.True(HoversPage.IsPageOpened);
    }

    [Test]
    public void Download()
    {
        DownloadPage.OpenPage();
        Assert.True(DownloadPage.IsPageOpened);
        
        DownloadPage.DownloadFile();
        Assert.True(DownloadPage.IsFileExists);
    }
}