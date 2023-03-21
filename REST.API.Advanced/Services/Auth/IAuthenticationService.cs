using REST.API.Basics.Models.Requests;

namespace REST.API.Basics.Services.Auth;

public interface IAuthenticationService
{
    Task<RestResponse> Authenticate();
    Task<CookieModelRequest> GetCookie();
}