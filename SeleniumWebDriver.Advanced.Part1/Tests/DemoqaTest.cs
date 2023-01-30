namespace SeleniumWebDriver.Advanced.Part1.Tests;

public class DemoqaTest: BaseTest
{
    [Test]
    public void Task1()
    {
        HomePage.OpenPage();
        Assert.True(HomePage.IsPageOpened);
        
        HomePage.ClickAlertFrameWindowBtn();
        AlertFramesWindowsPage.ClickAlertsBtn();
        Assert.True(AlertPage.IsPageOpened);
        
        AlertPage.ClickAlertBtn();
        Assert.True(AlertPage.IsAlertOpened);
        
        AlertPage.AcceptAlert();
        Assert.True(AlertPage.IsAlertClosed);
        
        AlertPage.ClickConfirmBtn();
        Assert.True(AlertPage.IsConfirmAlertOpened);
        
        AlertPage.AcceptAlert();
        Assert.True(AlertPage.IsAlertClosed);
        Assert.True(AlertPage.IsAfterConfirmAlertClosedTextAvailable);
        
        AlertPage.ClickPromptBtn();
        Assert.True(AlertPage.IsPromptAlertOpened);
        
        AlertPage.SendRandomlyGeneratedText();
        AlertPage.AcceptAlert();
        Assert.True(AlertPage.IsAlertClosed);
        Assert.True(AlertPage.IsAfterPromptAlertClosedTextAvailable);
    }
    
    [Test]
    public void Task2()
    {
        HomePage.OpenPage();
        Assert.True(HomePage.IsPageOpened);
        
        HomePage.ClickAlertFrameWindowBtn();
        AlertFramesWindowsPage.ClickNestedFramesBtn();
        Assert.True(NestedFramesPage.IsPageOpened);
        Assert.True(NestedFramesPage.IsParentAndChildTextRight);
        
        NestedFramesPage.ClickFrame();
        Assert.True(FramesPage.IsPageOpened);
        Assert.True(FramesPage.IsUpperAndLowerFramesEqual);
    }
    
    [Test]
    public void Task3()
    {
        HomePage.OpenPage();
        HomePage.ClickWidgetBtn();
        Assert.True(WidgetsPage.IsPageOpened);
        
        WidgetsPage.ClickProgressBtn();
        Assert.True(ProgressBarPage.IsPageOpened);
        
        ProgressBarPage.ClickStartStopBtn();
        ProgressBarPage.ClickStopBtn();
        Assert.True(ProgressBarPage.isProgressBar46Precent);
    }

    [Test]
    public void AddtionalTask()
    {
        HomePage.OpenPage();
        Assert.True(HomePage.IsPageOpened);
        
        HomePage.ClickAlertFrameWindowBtn();
        AlertFramesWindowsPage.ClickBrowserWindowsFramesBtn();
        Assert.True(BrowserWindowsPage.IsPageOpened);
        
        BrowserWindowsPage.ClickTabBtn();
        Assert.True(SamplePage.IsPageOpened);
        
        SamplePage.CloseTab();
        Assert.True(BrowserWindowsPage.IsPageOpened);
        
        BrowserWindowsPage.ClickLinksBtn();
        Assert.True(LinksPage.IsPageOpened);
        
        LinksPage.ClickHomeLink();
        Assert.True(HomePage.IsPageOpened);
        
        HomePage.MoveToPreviousTab();
        Assert.True(LinksPage.IsPageOpened);
    }
}