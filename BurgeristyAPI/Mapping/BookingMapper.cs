using AutoMapper;
using Burgeristy.DtoLayer.BookingDto;
using Burgeristy.EntityLayer.Entities;

namespace BurgeristyAPI.Mapping
{
    public class BookingMapper : Profile
    {
        public BookingMapper()
        {
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
        }
    }
}
