using AutoMapper;
using HotelListing.Models.DTOs;
using HotelListing.Models.Entities;

namespace HotelListing.Models.Mapper {
    public class MapperProfile: Profile {
        public MapperProfile()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTOCreate>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTOCreate>().ReverseMap();
        }
    }
}
