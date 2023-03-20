namespace REST.API.Basics.Utilities;

public static class FileReader
{
    public static string GetJsonTestData()
    {
        return File.ReadAllText("TestData/TestUser.json");
    }
}