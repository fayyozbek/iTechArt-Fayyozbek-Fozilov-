namespace UnitTesting.Utils;

public class Configurator
{
    private const string BaseUrlProperty = "baseUrl";
    
    public static readonly string BaseUrl = TestContext.Parameters[BaseUrlProperty];
}
