using REST.API.Basics.Models.Requests;

namespace REST.API.Basics.Services.Booking;

public class BookingService : BaseService, IBookingService
{
    public async Task<RestResponse> CreateBooking(BookingModelRequest modelRequest)
    {
        var request = new RestRequest("booking", Method.Post);
        request.AddJsonBody(modelRequest);
        return await ExecuteAsync(request);
    }
    public async Task<RestResponse> UpdateBooking(BookingModelRequest modelRequest)
    {
        var request = new RestRequest($"booking/{modelRequest.Bookingid}", Method.Put);
        request.AddJsonBody(modelRequest);
        return await ExecuteAsync(request);
    }

    public async Task<RestResponse> DeleteBooking(BookingModelRequest modelRequest)
    {
        var request = new RestRequest($"booking/{modelRequest.Bookingid}", Method.Delete);
        return await ExecuteAsync(request);
    }

    public async Task<RestResponse> GetBooking(BookingModelRequest modelRequest)
    {
        var request = new RestRequest($"booking/{modelRequest.Bookingid}", Method.Get);
        return await ExecuteAsync(request);
    }

    public async Task<RestResponse> GetBookings()
    {
        var request = new RestRequest("booking", Method.Get);
        return await ExecuteAsync(request);
    }
}