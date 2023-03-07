using PracticeExam.Core.BrowserConfiguration;
using PracticeExam.Core.Forms;

namespace PracticeExam.Test.Configurations;

public class AppConfiguration
{
    private const string UrlKey= "url";
    
    private const string BrowserKey= "browser";
    
    private const string StartArgumentKey= "startArguments";

    private const string ConditionTimeoutKey = "conditionTimeout";

    public static readonly string BaseUrl=  Configurator.GetConfiguration().GetSection(UrlKey).Value;


    public static BrowserModel BrowserModel
    {
        get
        {
            var browserModel = new BrowserModel();
            browserModel.BrowserName = Enum.Parse<BrowserEnum>(Configurator.GetConfiguration().GetSection(BrowserKey).Value, true);
            browserModel.BrowserSettings = Configurator.GetConfiguration().GetSection(StartArgumentKey).Get<string[]>();
            browserModel.ConditionTimeWait = Convert.ToInt32(Configurator.GetConfiguration().GetSection(ConditionTimeoutKey).Value);
            return browserModel;
        }
    }
}