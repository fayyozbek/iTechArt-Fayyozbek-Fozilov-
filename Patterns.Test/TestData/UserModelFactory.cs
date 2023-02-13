using Patterns.Test.Model;

namespace Patterns.Test.TestData;

public static class UserModelFactory
{
    public static readonly UserModel TestUser = new()
    {
        Username = "standard_user",
        Password = "secret_sauce"
    };
}