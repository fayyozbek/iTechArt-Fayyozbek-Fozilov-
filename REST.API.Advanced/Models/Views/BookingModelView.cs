namespace REST.API.Basics.Models.Requests.Views;

public class BookingModelView
{
    public int BookingId { get; set; }
    public int RoomId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool DepositPaid { get; set; }
    public BookingDates BookingDates { get; set; }
}