namespace REST.API.Basics.Services.Auth;

public interface IAuthenticationService
{
    Task<RestResponse> Authenticate();
}