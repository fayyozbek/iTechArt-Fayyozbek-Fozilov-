using PracticeExam.Core.BrowserConfiguration;
using PracticeExam.Test.Pages;

namespace PracticeExam.Test.Steps;

public class TaskPageStep
{
    public TaskPageStep(Browser browser)
    {
        Browser = browser;
    }

    private  Browser Browser { get; }

    private TaskPage TaskPage => new(Browser);
    
    public TaskPageStep GoToPageAndUnselectElements()
    {
        TaskPage.OpenPage();
        TaskPage.ScrollToTestTaskLabel();
        while (true)
        {
            try
            {
                var date = TaskPage.GetTextSelectedDate().Split('-');
                if (TaskPage.SelectedYearTxt.Contains(date[0]))
                {
                    TaskPage.ClickAccentText();
                    
                }
                
                
            }
            catch (NoSuchElementException)
            {
                break;
            } 
        }

        return this;
    }

    public TaskPageStep GoToCurrentDate()
    {
        TaskPage.ClickAccentText();
        while (true)
        {
            try
            {
                if (TaskPage.isDisplayedCurrentDate)
                {
                    break;
                }
            }
            catch (NoSuchElementException)
            {
                TaskPage.CLickRightArrow();
            }
        }

        TaskPage.ClickCurrentDate();    
        return this;
    }

    public string SelectPickedDate(int whichDate)
    {
        return TaskPage
            .WaitUntilCurrentDateLoaded()
            .SelectPickedDate(whichDate)
            .SelectedDateText();
    }

}