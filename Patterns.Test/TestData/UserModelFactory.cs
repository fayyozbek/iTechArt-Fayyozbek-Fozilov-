namespace Patterns.Test.TestData;

public static class UserModelFactory
{
    public static readonly UserModel TestUser = new()
    {
        Username = "standard_user",
        Password = "secret_sauce",
        FirstName = "Somebody",
        LastName = "LAstttt",
        ZipCode = "1000000000"
    };
}