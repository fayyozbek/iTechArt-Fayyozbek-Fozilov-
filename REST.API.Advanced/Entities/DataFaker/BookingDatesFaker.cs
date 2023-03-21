using Bogus;
using REST.API.Basics.Models.Requests;

namespace REST.API.Basics.Entities.DataFaker;

public static class BookingDatesFaker
{
    public static Faker<BookingDates> CorrectModel()
    {
        var checkinDateTime = RandomDay();
        var checkoutDateTime = checkinDateTime.AddDays(5);
        string checkin;
        string checkout;
        if (checkinDateTime.Month<10)
        {
            checkin = $"{checkinDateTime.Year}-0{checkinDateTime.Month}-{checkinDateTime.Day}"; 
            checkout = $"{checkoutDateTime.Year}-0{checkoutDateTime.Month}-{checkoutDateTime.Day}";
        }
        else
        {
            checkin = $"{checkinDateTime.Year}-{checkinDateTime.Month}-{checkinDateTime.Day}"; 
            checkout = $"{checkoutDateTime.Year}-{checkoutDateTime.Month}-{checkoutDateTime.Day}";
        }
        return new Faker<BookingDates>()
            .RuleFor(u => u.Checkin,checkin )
            .RuleFor(u => u.Checkout, checkout);
    }
    
    private static Random gen = new Random();
    private static DateTime RandomDay()
    {
        DateTime start = new DateTime(2018, 1, 1);
        int range = (DateTime.Today - start).Days;           
        return start.AddDays(gen.Next(range));
    }
}