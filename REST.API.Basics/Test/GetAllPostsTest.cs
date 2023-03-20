using System.Net;
using REST.API.Basics.Models;

namespace REST.API.Basics;

public class GetAllPostsTest :BaseTest
{
    [Fact]
    public void GetAllPosts_Returns200AndSortedPosts()
    {
        var request = new RestRequest("/posts", Method.Get);
        var response = Client.Execute(request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var posts = JsonConvert.DeserializeObject<List<Post>>(response.Content);
        var expectedList = posts.OrderBy(x => x.Id);
        Assert.True(expectedList.SequenceEqual(posts));
    }
}