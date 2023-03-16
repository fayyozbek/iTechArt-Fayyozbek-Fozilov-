using RestSharp;

namespace REST.API.Basics.Services;

public abstract class BaseService
{
    protected readonly IRestClient _client;

    public BaseService()
    {
        _client = new RestClient("https://automationintesting.online/");
    }

    protected async Task<RestResponse> ExecuteAsync(RestRequest request)
    {
        return await _client.ExecuteAsync(request);
    }
}