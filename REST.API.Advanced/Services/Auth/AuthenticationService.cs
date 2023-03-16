using REST.API.Basics.Entities.DataFactory;

namespace REST.API.Basics.Services.Auth;

public class AuthenticationService : BaseService, IAuthenticationService
{
    public async Task<RestResponse> Authenticate()
    {
        var request = new RestRequest("auth/login", Method.Post);
        request.AddJsonBody(AuthenticationModelRequestFactory.LoginData);
        return await ExecuteAsync(request);
    }
}