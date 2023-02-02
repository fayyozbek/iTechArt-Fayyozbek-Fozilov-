namespace WorkWithComponentsSelenium.Pages;

public class ActionsPage : BasePage
{
    public ActionsPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => HerokuAppXpath.XPathQueryGenerator( "sliderContainer");

    protected override string UrlPath => "/horizontal_slider";

    private readonly By _sliderLocator = HerokuAppXpath.XPathQueryGenerator("class", "sliderContainer", "input");
    
    private readonly By _sliderResultLocator = HerokuAppXpath.XPathQueryGenerator("class", "sliderContainer", "span");

    private IWebElement Slider => WebDriver.FindElement(_sliderLocator);
    
    private IWebElement SliderResult => WebDriver.FindElement(_sliderResultLocator);

    public string ExpectedNumberInSliderText => SliderResult.Text;

    public void ChangeSlider(int number)
    {
        ActionBuilder.MoveToElement(Slider);
        ActionBuilder.Click();
        ActionBuilder.SendKeys(Keys.ArrowLeft);
        ActionBuilder.SendKeys(Keys.ArrowLeft);
        ActionBuilder.SendKeys(Keys.ArrowLeft);
        ActionBuilder.SendKeys(Keys.ArrowLeft);
        ActionBuilder.SendKeys(Keys.ArrowLeft);
        for (int i = 0; i < number; i++)
        {
            ActionBuilder.SendKeys(Keys.ArrowRight);
        }
        
        ActionBuilder.Build();
        ActionBuilder.Perform();
    }
}