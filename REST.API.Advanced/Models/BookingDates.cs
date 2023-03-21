using Newtonsoft.Json;

namespace REST.API.Basics.Models.Requests;

public class BookingDates
{
    public string Checkin { get; set; }
    
    public string Checkout { get; set; }
}