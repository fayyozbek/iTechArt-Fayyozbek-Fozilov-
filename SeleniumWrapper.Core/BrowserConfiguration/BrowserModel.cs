namespace SeleniumWrapper.Core.BrowserConfiguration;

public record BrowserModel
{
    public BrowserEnum BrowserName { get; set; }
    
    public string[] BrowserSettings { get; set; }
    
    public int ConditionTimeWait { get; set; }
};