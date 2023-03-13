using PracticeExam.Core.BrowserConfiguration;
using PracticeExam.Test.Pages;

namespace PracticeExam.Test.Steps;

public class TaskPageStep
{
    public TaskPageStep(Browser browser)
    {
        Browser = browser;
    }

    private Browser Browser { get; }

    private TaskPage TaskPage => new(Browser);

    public TaskPageStep GoToPageAndUnselectElements()
    {
        TaskPage.OpenPage();
        TaskPage.ScrollToTestTaskLabel();
        while (true)
            try
            {
                var date = DateTime.Parse(TaskPage.GetTextSelectedDate().TrimEnd(','));
                TaskPage
                    .ClickSelectedYear()
                    .ClickPickYear(date.Year)
                    .ClickPickMonth(date.Month)
                    .ClickPickedDate(date.Day);
            }
            catch (NoSuchElementException)
            {
                break;
            }

        return this;
    }

    private TaskPage PickDate(int toWhichDate)
    {
        var date = DateTime.Today.AddDays(toWhichDate);
        TaskPage.ClickSelectedYear();
        while (true)
            try
            {
                TaskPage.ClickPickYear(date.Year);
                break;
            }
            catch (NoSuchElementException)
            {
                if (toWhichDate < 0)
                    TaskPage.ClickLastYearIntheList();
                else
                    TaskPage.ClickFirstYearIntheList();
                TaskPage.ClickSelectedYear();
            }

        TaskPage
            .ClickPickMonth(date.Month)
            .ClickPickedDate(date.Day);
        return TaskPage;
    }

    public DateTime SelectPickedDate(int whichDate)
    {
        var date = DateTime.Parse(PickDate(whichDate).GetTextSelectedDate().TrimEnd(','));
        return date;
    }
}