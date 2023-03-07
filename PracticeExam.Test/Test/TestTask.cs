using NUnit.Allure.Core;

namespace PracticeExam.Test.Test;

[AllureNUnit]
public class TestTask :BaseTest
{
    [Test]
    [TestCase(3, 10)]
    public void CheckTestDone(int onWhichDate, int expectedDate)
    {
        var date = TaskPageStep
            .GoToPageAndUnselectElements()
            .GoToCurrentDate()
            .SelectPickedDate(onWhichDate);
        Assert.That(date, Is.EqualTo(expectedDate.ToString()));
    }
}