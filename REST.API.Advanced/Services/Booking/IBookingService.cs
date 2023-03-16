using REST.API.Basics.Models.Requests;

namespace REST.API.Basics.Services.Booking;

public interface IBookingService
{ 
    Task<RestResponse> CreateBooking(BookingModelRequest modelRequest);
    Task<RestResponse> UpdateBooking(BookingModelRequest modelRequest);
    Task<RestResponse> DeleteBooking(BookingModelRequest modelRequest);
    Task<RestResponse> GetBooking(BookingModelRequest modelRequest);
    Task<RestResponse> GetBookings();
}