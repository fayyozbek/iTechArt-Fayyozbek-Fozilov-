using NUnit.Allure.Core;

namespace PracticeExam.Test.Test;

[AllureNUnit]
public class TestTask : BaseTest
{
    [Test]
    [TestCase(100000)]
    public void CheckTestDone(int onWhichDate)
    {
        var date = TaskPageStep
            .GoToPageAndUnselectElements()
            .SelectPickedDate(onWhichDate);
        Assert.That(date, Is.EqualTo(DateTime.Today.AddDays(onWhichDate)));
    }
}