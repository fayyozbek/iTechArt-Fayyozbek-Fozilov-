using REST.API.Basics.Entities.DataFactory;
using REST.API.Basics.Services.Auth;
using REST.API.Basics.Services.Booking;

namespace REST.API.Basics.Test;

public class BookingTests
{
    private readonly IAuthenticationService _authService;
    private readonly IBookingService _bookingService;
    public BookingTests()
    {
       _authService = new AuthenticationService();
       _bookingService = new BookingService();
    }
    
    [Fact]
    public async Task CreateBooking_ShouldAddBookingToList()
    { 
        var cookie= await _authService.GetCookie();
        var bookingRequest = BookingModelRequestFactory.BookingModel;

        var response = await _bookingService.CreateBooking(bookingRequest);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        bookingRequest.Bookingid = JsonConvert.DeserializeObject<BookingModelRequest>(response.Content).Bookingid;

        var getResponse = await _bookingService.GetBooking(bookingRequest , cookie );
        getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateBooking_ShouldChangeFirstName()
    {
        var cookie= await _authService.GetCookie();
        var bookingRequest = BookingModelRequestFactory.BookingModel;

        var createResponse = await _bookingService.CreateBooking(bookingRequest);
        bookingRequest.Bookingid =
            JsonConvert.DeserializeObject<BookingModelRequest>(createResponse.Content).Bookingid;

        bookingRequest.Firstname = "NewFirstName";

        var response = await _bookingService.UpdateBooking(bookingRequest , cookie);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var getResponse = await _bookingService.GetBooking(bookingRequest, cookie);
        var bookingResponse = JsonConvert.DeserializeObject<BookingModelRequest>(getResponse.Content);
        bookingResponse.Firstname.Should().Be("NewFirstName");
    }

    [Fact]
    public async Task DeleteBooking_ShouldRemoveBookingFromList()
    {
        var cookie= await _authService.GetCookie();
        var bookingRequest = BookingModelRequestFactory.BookingModel;

        var createResponse = await _bookingService.CreateBooking(bookingRequest);
        bookingRequest.Bookingid =
            JsonConvert.DeserializeObject<BookingModelRequest>(createResponse.Content).Bookingid;

        var response = await _bookingService.DeleteBooking(new BookingModelRequest { Bookingid =bookingRequest.Bookingid  }, cookie);

        response.StatusCode.Should().Be(HttpStatusCode.Accepted);

        var getResponse = await _bookingService.GetBooking(bookingRequest, cookie);
        getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

}

