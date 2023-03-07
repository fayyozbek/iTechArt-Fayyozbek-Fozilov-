using PracticeExam.Core.BrowserConfiguration;
using PracticeExam.Core.Elements;

namespace PracticeExam.Test.Pages;

public class TaskPage :BasePage
{
    public TaskPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//pre");
    protected override string UrlPath { get; }

    private readonly By _testTaskElementLocator = By.XPath("//*[contains(@href,\"test-task\")]");

    private readonly By _selectedElementLocator = By.XPath("//*[contains(@class,\"v-btn--active\")]");
    
    private readonly By _selectedElementTextLocator = By.XPath("//*[contains(@class,\"v-btn--active\")]//div");
    
    private readonly By _selectedYearLocator = By.XPath("//*[contains(@class,\"v-date-picker-title__year\")]");

    private readonly By _rightDatePickerArrowLocator = By.XPath("//*[contains(@class,\"mdi-chevron-right\")]");

    private readonly By _accentTextLocator = By.XPath("//*[contains(@class,\"accent--text\")]");
    
    private readonly By _accentTextBtnLocator = By.XPath("//*[contains(@class,\"accent--text\")]//button");

    private readonly By _currentDateLocator = By.XPath("//*[contains(@class,\"v-date-picker-table__current\")]");

    private readonly By _currentDateNumberLocator = By.XPath("//*[contains(@class,\"v-date-picker-table__current\")]//div");

    private readonly By _selectedDatesSpanLocator =
        By.XPath("//*[contains(@class,\"col-sm-6 col-12\") and contains(text(), \"Selected dates\") ]//span");

    private Label SelectedElement => new(_selectedElementLocator, "Selected Elememnt");
    private Label SelectedDatesSpan => new(_selectedDatesSpanLocator, "Selected Dates");

    private Label SelectedYear => new(_selectedYearLocator, "Selected Year");

    //private IReadOnlyCollection<IWebElement> SelectedDatesSpan => Browser.WebDriver.FindElements(_selectedDatesSpanLocator);
    
    private Label SelectedElementText => new(_selectedElementTextLocator, "Selected Elememnt Text");
    
    
    
    private Label AccentText => new(_accentTextLocator, "Accent Text");

    private Label AccentTextBtn => new(_accentTextBtnLocator, "Accent Text");

    private Label TestTaskLabel => new(_testTaskElementLocator, "Test Task Label");

    private Label RightDatePickerArrow => new(_rightDatePickerArrowLocator, "Right Arrow");

    private Label CurrentDate => new(_currentDateLocator, "Current Date");

    private Label CurrentDateNumber => new(_currentDateNumberLocator, "Current Date Number");

    public TaskPage ScrollToTestTaskLabel()
    {
        TestTaskLabel.ScrollToView();
        return this;
    }

    public TaskPage ClickSelectedYear()
    {
        SelectedYear.Click();
        return this;
    }
    
    private Label PickMonth()
    
    public string SelectedYearTxt => SelectedYear.GetText();
    
    public TaskPage WaitUntilCurrentDateLoaded()
    {
        Browser.BrowserWait.Until(_ => CurrentDateNumber.GetText().Contains("7"));
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
        var locator = By.XPath($"//*[contains(@class,\"v-btn__content\") and text()=\"{Convert.ToInt16(CurrentDateNumber.GetText())+whichNumber}\"]");
        return new Label(locator, "picked date");
    }
    
    public TaskPage SelectPickedDate(int whichDate)
    {
        PickDate(whichDate).Click();
        return this;
    }

    public string SelectedDateText()
    {
        return SelectedElementText.GetText();
    }
    public TaskPage ClickSelectedElement()
    {
        SelectedElement.Click();
        return this;
    }

    public TaskPage ClickAccentText()
    {
        AccentText.Click();
        return this;
    }
    
    public TaskPage ClickCurrentDate()
    {
        CurrentDate.Click();
        return this;
    }

    public TaskPage CLickRightArrow()
    {
        RightDatePickerArrow.Click();
        return this;
    }

    public bool isDisplayedCurrentDate => CurrentDate.IsDisplayed();
    public bool isDisplayedSelectedDate => SelectedElement.IsDisplayed();
}