using REST.API.Basics.Entities.DataFactory;
using REST.API.Basics.Models.Requests;

namespace REST.API.Basics.Services.Auth;

public class AuthenticationService : BaseService, IAuthenticationService
{
    public async Task<RestResponse> Authenticate()
    {
        var request = new RestRequest("auth/login", Method.Post);
        request.AddJsonBody(AuthenticationModelRequestFactory.LoginData);
        return await ExecuteAsync(request);
    }

    public async Task<CookieModelRequest> GetCookie()
    {
        var authenticate = await Authenticate();
        var setCookie = authenticate.Headers
            .ToList()
            .Where(x => x.Name == "Set-Cookie")
            .Select(x => x.Value)
            .FirstOrDefault()
            .ToString()
            .Split(";");
        return new CookieModelRequest()
        {
            Token = setCookie[0].Split("=")[1],
            Path =  setCookie[1].Split("=")[1]
        };
    }
}