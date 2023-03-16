using Newtonsoft.Json;

namespace REST.API.Basics.Models.Requests;

public class BookingModelRequest
{
    public int Bookingid { get; set; }
    
    public int Roomid { get; set; }
    
    public string Firstname { get; set; }
    
    public string Lastname { get; set; }
    
    public bool Depositpaid { get; set; }
    
    public BookingDates Bookingdates { get; set; }
}