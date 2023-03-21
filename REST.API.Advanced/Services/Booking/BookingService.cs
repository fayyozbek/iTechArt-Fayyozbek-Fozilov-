using REST.API.Basics.Models.Requests;

namespace REST.API.Basics.Services.Booking;

public class BookingService : BaseService, IBookingService
{
    public async Task<RestResponse> CreateBooking(BookingModelRequest modelRequest)
    {
        var request = new RestRequest("booking/", Method.Post);
        request.AddJsonBody(modelRequest);
        return await ExecuteAsync(request);
    }
    public async Task<RestResponse> UpdateBooking(BookingModelRequest modelRequest, CookieModelRequest cookie)
    {
        var request = new RestRequest($"booking/{modelRequest.Bookingid}", Method.Put);
        request.AddJsonBody(modelRequest);
        request.AddCookie("token", cookie.Token, cookie.Path, "automationintesting.online");
        return await ExecuteAsync(request);
    }

    public async Task<RestResponse> DeleteBooking(BookingModelRequest modelRequest, CookieModelRequest cookie)
    {
        var request = new RestRequest($"booking/{modelRequest.Bookingid}", Method.Delete);
        request.AddCookie("token", cookie.Token, cookie.Path, "automationintesting.online");
        return await ExecuteAsync(request);
    }

    public async Task<RestResponse> GetBooking(BookingModelRequest modelRequest, CookieModelRequest cookie )
    {
        var request = new RestRequest($"booking/{modelRequest.Bookingid}", Method.Get);
        request.AddCookie("token", cookie.Token, cookie.Path, "automationintesting.online");
        return await ExecuteAsync(request);
    }

    public async Task<RestResponse> GetBookings(CookieModelRequest cookie)
    {
        var request = new RestRequest("booking", Method.Get);
        request.AddCookie("token", cookie.Token, cookie.Path, "automationintesting.online");
        return await ExecuteAsync(request);
    }
}