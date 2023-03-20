using System.Net;
using REST.API.Basics.Models;
using REST.API.Basics.Utilities;
using RestSharp;

namespace REST.API.Basics;

public class RestAPITests
{
    private readonly RestClient _client;

    public RestAPITests()
    {
        _client = new RestClient("https://jsonplaceholder.typicode.com");;
    }

    [Fact]
    public void GetAllPosts_Returns200AndSortedPosts()
    {
        var request = new RestRequest("/posts", Method.Get);
        var response = _client.Execute(request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var posts = JsonConvert.DeserializeObject<List<Post>>(response.Content);
        var expectedList = posts.OrderBy(x => x.Id);
        Assert.True(expectedList.SequenceEqual(posts));
    }

    [Fact]
    public void GetPostById_Returns200AndCorrectData()
    {
        var request = new RestRequest("/posts/99", Method.Get);
        var response = _client.Execute(request);
        var post = JsonConvert.DeserializeObject<Post>(response.Content);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(10, post.UserId );
        Assert.Equal(99, post.Id );
        Assert.NotEmpty(post.Body);
    }

    [Fact]
    public void GetPostById_Return404AndEmptyBody()
    {
        var request = new RestRequest("/posts/150", Method.Get);
        var response = _client.Execute(request);
        var responseBody = response.Content.Trim();
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Contains("{}", responseBody);

    }
    
    [Fact]
    public void CreatePost_ReturnsCreatedPost()
    {
        var post = new Post
        {
            UserId = 1,
            Title = "New post",
            Body = "This is the body of the new post"
        };
        var request = new RestRequest("/posts", Method.Post);
        request.AddJsonBody(post);

        var response = _client.Execute(request);
        var createdPost = JsonConvert.DeserializeObject<Post>(response.Content);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.Equal(post.UserId, createdPost.UserId);
        Assert.Equal(post.Title, createdPost.Title);
        Assert.Equal(post.Body, createdPost.Body);
    }

    [Fact]
    public void GetAllUsers_ReturnsUsersList()
    {
        var request = new RestRequest("/users", Method.Get);
        var json = FileReader.GetJsonTestData();
        var expectedUserDeserialize = JsonConvert.DeserializeObject<User>(json);
        var expectedUser = JsonConvert.SerializeObject(expectedUserDeserialize);
        
        var response = _client.Execute(request);
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
        
        var response = _client.Execute(request);
        var user = JsonConvert.DeserializeObject<User>(response.Content);
        var actualUser = JsonConvert.SerializeObject(user);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expectedUser,actualUser);
    }
}