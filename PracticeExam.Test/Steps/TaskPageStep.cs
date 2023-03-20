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
        var yearRange = DateTime.Today.Year;
        TaskPage.ClickSelectedYear();
        while (!(yearRange - 100 <= date.Year && date.Year<= yearRange+100))
        {
            if (toWhichDate < 0)
            {
                TaskPage.ClickLastYearIntheList();
                yearRange -= 100;
            }
            else
            {
                TaskPage.ClickFirstYearIntheList();
                yearRange += 100;
            }
            TaskPage.ClickSelectedYear();
        }
        TaskPage
            .ClickPickYear(date.Year)
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