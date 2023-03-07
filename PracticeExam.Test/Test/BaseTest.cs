using PracticeExam.Core.BrowserConfiguration;
using PracticeExam.Test.Configurations;
using PracticeExam.Test.Steps;

namespace PracticeExam.Test.Test;

public class BaseTest
{
    protected Browser Browser { get; private set; }

    protected TaskPageStep TaskPageStep { get; private set; }


    [SetUp]
    public void SetUp()
    {
        Browser = BrowserService.StartBrowser(AppConfiguration.BrowserModel);

        TaskPageStep = new(Browser);
    }

    [TearDown]
    public void TearDown()
    {
        Browser.Quit();
    }
}