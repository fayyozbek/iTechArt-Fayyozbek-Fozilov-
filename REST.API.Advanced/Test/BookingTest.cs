using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using REST.API.Basics.Entities.DataFactory;
using REST.API.Basics.Models.Requests;
using REST.API.Basics.Services.Auth;
using REST.API.Basics.Services.Booking;

namespace REST.API.Basics.Test;

public class BookingTests
{
    private readonly IAuthenticationService _authService;
    private readonly IBookingService _bookingService;
    private readonly BookingModelRequest _bookingRequest = BookingModelRequestFactory.BookingModel;
    public BookingTests()
    {
       _authService = new AuthenticationService();
       _bookingService = new BookingService();
    }
    
    [Fact]
    public async Task CreateBooking_ShouldAddBookingToList()
    {
        var login  = await _authService.Authenticate();
        var bookingRequest = BookingModelRequestFactory.BookingModel;


        var response = await _bookingService.CreateBooking(bookingRequest);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var createdResponse = JsonConvert.DeserializeObject<BookingModelRequest>(response.Content);

        var getResponse = await _bookingService.GetBooking(new BookingModelRequest { Bookingid = createdResponse.Bookingid });
        getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateBooking_ShouldChangeFirstName()
    {
        // Arrange
        await _authService.Authenticate();

        // Create a new booking
        var createResponse = await _bookingService.CreateBooking(_bookingRequest);

        // Modify the booking's first name
        _bookingRequest.Firstname = "NewFirstName";

        // Act
        var response = await _bookingService.UpdateBooking(_bookingRequest);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        // Verify that first name is changed
        var getResponse = await _bookingService.GetBooking(new BookingModelRequest { Bookingid = int.Parse(createResponse.Content) });
        var bookingResponse = JsonConvert.DeserializeObject<BookingModelRequest>(getResponse.Content);
        bookingResponse.Firstname.Should().Be("NewFirstName");
    }

    [Fact]
    public async Task DeleteBooking_ShouldRemoveBookingFromList()
    {
        // Arrange
        await _authService.Authenticate();

        // Create a new booking
        var createResponse = await _bookingService.CreateBooking(_bookingRequest);

        // Act
        var response = await _bookingService.DeleteBooking(new BookingModelRequest { Bookingid = int.Parse(createResponse.Content) });

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        // Verify that booking is removed from the list
        var getResponse = await _bookingService.GetBooking(new BookingModelRequest { Bookingid = int.Parse(createResponse.Content) });
        getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    }

