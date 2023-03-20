using RestSharp;

namespace REST.API.Basics;

public  abstract class BaseTest
{
    protected readonly RestClient Client;

    protected BaseTest()
    {
        Client = new RestClient("https://jsonplaceholder.typicode.com");;

    }
}