using REST.API.Basics.Models.Requests;

namespace REST.API.Basics.Entities.DataFactory;

public static class AuthenticationModelRequestFactory
{
    public static AuthenticationModelRequest LoginData = new()
    {
        Username = "admin",
        Password = "password"
    };
}