namespace SeleniumWebDriver.Advanced.Part1.Utilities;

public static class TextGenerator
{
    public static string GenerateRandomText()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var length = 10;
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}