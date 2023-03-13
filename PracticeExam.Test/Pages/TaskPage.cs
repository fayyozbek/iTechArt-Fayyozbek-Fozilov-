using PracticeExam.Core.BrowserConfiguration;
using PracticeExam.Core.Elements;

namespace PracticeExam.Test.Pages;

public class TaskPage : BasePage
{
    private readonly By _accentTextBtnLocator = By.XPath("//*[contains(@class,\"accent--text\")]//button");

    private readonly By _firstYearInTheListLocator = By.XPath("//*[contains(@class, \"v-date-picker-years\")]//li");

    private readonly By _lastYearInTheListLocator =
        By.XPath("//*[contains(@class, \"v-date-picker-years\")]//li[last()]");

    private readonly By _selectedDatesSpanLocator =
        By.XPath("//*[contains(@class,\"col-sm-6 col-12\") and contains(text(), \"Selected dates\") ]//span");

    private readonly By _selectedElementTextLocator = By.XPath("//*[contains(@class,\"v-btn--active\")]//div");

    private readonly By _selectedYearLocator = By.XPath("//*[contains(@class,\"v-date-picker-title__year\")]");

    private readonly By _testTaskElementLocator = By.XPath("//*[contains(@href,\"test-task\")]");

    public TaskPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//pre");
    protected override string UrlPath { get; }

    private Label SelectedDatesSpan => new(_selectedDatesSpanLocator, "Selected Dates");

    private Label SelectedYear => new(_selectedYearLocator, "Selected Year");

    private Label FirstYearInTheList => new(_firstYearInTheListLocator, "First Year in the list");

    private Label LastYearInTheList => new(_lastYearInTheListLocator, "Last Year in the list");

    private Label SelectedElementText => new(_selectedElementTextLocator, "Selected Elememnt Text");

    private Label AccentTextBtn => new(_accentTextBtnLocator, "Accent Text");

    private Label TestTaskLabel => new(_testTaskElementLocator, "Test Task Label");

    public TaskPage ScrollToTestTaskLabel()
    {
        TestTaskLabel.ScrollToView();
        return this;
    }

    public TaskPage ClickFirstYearIntheList()
    {
        FirstYearInTheList.Click();
        return this;
    }

    public TaskPage ClickLastYearIntheList()
    {
        LastYearInTheList.Click();
        return this;
    }

    public TaskPage ClickSelectedYear()
    {
        SelectedYear.Click();
        return this;
    }

    private Label PickMonth(int monthNumber)
    {
        By monthLocator;
        switch (monthNumber)
        {
            case 1:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"Jan\")]");
                break;
            case 2:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"Feb\")]");
                break;
            case 3:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"Mar\")]");
                break;
            case 4:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"Apr\")]");
                break;
            case 5:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"May\")]");
                break;
            case 6:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"Jun\")]");
                break;
            case 7:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"Jul\")]");
                break;
            case 8:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"Aug\")]");
                break;
            case 9:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"Sep\")]");
                break;
            case 10:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"Oct\")]");
                break;
            case 11:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"Nov\")]");
                break;
            case 12:
                monthLocator =
                    By.XPath(
                        "//*[contains(@class,\"v-btn__content\") and contains(text(),\"Dec\")]");
                break;
            default:
                monthLocator = By.XPath("//*[contains(@class,\"v-btn--active\")]");
                break;
        }

        return new Label(monthLocator, "Month");
    }

    private Label PickYear(int yearNumber)
    {
        var yearLocator =
            By.XPath($"//*[contains(@class, \"v-date-picker-years\")]//li[contains(text(),\"{yearNumber}\")]");
        return new Label(yearLocator, "Year");
    }

    public TaskPage ClickPickYear(int whichYear)
    {
        PickYear(whichYear).Click();
        return this;
    }

    public TaskPage ClickPickMonth(int whichMonth)
    {
        PickMonth(whichMonth).Click();
        return this;
    }

    public string GetTextSelectedDate()
    {
        return SelectedDatesSpan.GetText();
    }

    public string GetAccentTextTxt()
    {
        return AccentTextBtn.GetText();
    }

    public Label PickDate(int whichNumber)
    {
        var locator = By.XPath($"//*[contains(@class,\"v-btn__content\") and contains(text(),\"{whichNumber}\")]");
        return new Label(locator, "picked date");
    }

    public TaskPage ClickPickedDate(int whichDate)
    {
        PickDate(whichDate).Click();
        return this;
    }

    public string SelectedDateText()
    {
        return SelectedElementText.GetText();
    }
}