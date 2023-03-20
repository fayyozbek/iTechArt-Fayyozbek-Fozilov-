using REST.API.Basics.Entities.DataFactory;
using REST.API.Basics.Models;

namespace REST.API.Basics;

public class CreatePost : BaseTest
{
    [Fact]
    public void CreatePost_ReturnsCreatedPost()
    {
        var post = PostFactory.PostTestModel;
        var request = new RestRequest("/posts", Method.Post);
        request.AddJsonBody(post);  

        var response = Client.Execute(request);
        var createdPost = JsonConvert.DeserializeObject<Post>(response.Content);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.Equal(post.UserId, createdPost.UserId);
        Assert.Equal(post.Title, createdPost.Title);
        Assert.Equal(post.Body, createdPost.Body);
    }
}