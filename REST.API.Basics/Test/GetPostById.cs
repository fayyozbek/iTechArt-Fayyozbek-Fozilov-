using REST.API.Basics.Models;

namespace REST.API.Basics;

public class GetPostById : BaseTest
{
    [Fact]
    public void GetPostById_Returns200AndCorrectData()
    {
        var request = new RestRequest("/posts/99", Method.Get);
        var response = Client.Execute(request);
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
        var response = Client.Execute(request);
        var responseBody = response.Content.Trim();
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Contains("{}", responseBody);

    }
}