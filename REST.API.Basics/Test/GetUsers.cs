using REST.API.Basics.Models;
using REST.API.Basics.Utilities;

namespace REST.API.Basics;

public class GetUsers : BaseTest
{
    [Fact]
    public void GetAllUsers_ReturnsUsersList()
    {
        var request = new RestRequest("/users", Method.Get);
        var json = FileReader.GetJsonTestData();
        var expectedUserDeserialize = JsonConvert.DeserializeObject<User>(json);
        var expectedUser = JsonConvert.SerializeObject(expectedUserDeserialize);
        
        var response = Client.Execute(request);
        var users = JsonConvert.DeserializeObject<List<User>>(response.Content);
        var actualUser = JsonConvert.SerializeObject(users[4]);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expectedUser,actualUser);
    }
    
    [Fact]
    public void GetFifthUsers_ReturnsUser()
    {
        var request = new RestRequest("/users/5", Method.Get);
        var json = FileReader.GetJsonTestData();
        var expectedUserDeserialize = JsonConvert.DeserializeObject<User>(json);
        var expectedUser = JsonConvert.SerializeObject(expectedUserDeserialize);
        
        var response = Client.Execute(request);
        var user = JsonConvert.DeserializeObject<User>(response.Content);
        var actualUser = JsonConvert.SerializeObject(user);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expectedUser,actualUser);
    }
    
}