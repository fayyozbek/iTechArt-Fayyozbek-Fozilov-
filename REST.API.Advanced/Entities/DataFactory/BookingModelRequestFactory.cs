using REST.API.Basics.Entities.DataFaker;
using REST.API.Basics.Models.Requests;

namespace REST.API.Basics.Entities.DataFactory;

public static class BookingModelRequestFactory
{
    public static  BookingModelRequest BookingModel=>BookingModelRequestFaker.CorrectModel();
}