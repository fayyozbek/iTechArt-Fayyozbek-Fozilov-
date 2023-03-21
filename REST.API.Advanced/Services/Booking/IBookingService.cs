using REST.API.Basics.Models.Requests;

namespace REST.API.Basics.Services.Booking;

public interface IBookingService
{ 
    Task<RestResponse> CreateBooking(BookingModelRequest modelRequest);
    Task<RestResponse> UpdateBooking(BookingModelRequest modelRequest, CookieModelRequest cookie);
    Task<RestResponse> DeleteBooking(BookingModelRequest modelRequest, CookieModelRequest cookie);
    Task<RestResponse> GetBooking(BookingModelRequest modelRequest, CookieModelRequest cookie );
    Task<RestResponse> GetBookings(CookieModelRequest cookie);
}