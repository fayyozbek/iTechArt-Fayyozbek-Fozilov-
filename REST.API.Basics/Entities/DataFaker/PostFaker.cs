using Bogus;
using REST.API.Basics.Models;

namespace REST.API.Basics.Entities.DataFaker;

public static class PostFacker
{
    public static Faker<Post> CorrectModel()
    {
        return new Faker<Post>()
            .RuleFor(p => p.UserId, 1)
            .RuleFor(p => p.Title, f => f.Lorem.Sentence())
            .RuleFor(p => p.Body, f => f.Lorem.Text());
    }
}