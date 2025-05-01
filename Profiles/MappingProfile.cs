using AutoMapper;
using TheBridge.Data.Entities;
using TheBridge.Dtos;

namespace TheBridge.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, UpdateCityDto>().ReverseMap();

        }
    }
}
