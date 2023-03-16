using Bogus;
using REST.API.Basics.Models.Requests;

namespace REST.API.Basics.Entities.DataFaker;

public static class BookingModelRequestFaker
{
    public static Faker<BookingModelRequest> CorrectModel()
    {
        return new Faker<BookingModelRequest>()
            .RuleFor(u=>u.Bookingid, 2)
            .RuleFor(u => u.Roomid, 1)
            .RuleFor(u => u.Firstname, f => f.Person.FirstName)
            .RuleFor(u => u.Lastname, f => f.Person.LastName)
            .RuleFor(u => u.Depositpaid, false)
            .RuleFor(u => u.Bookingdates, BookingDatesFaker.CorrectModel());
    }
}