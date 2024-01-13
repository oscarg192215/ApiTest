using ApiTest.Models.DTO;
using AutoMapper;

namespace ApiTest.Models.Profiles
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, PropertyDTO>();
            CreateMap<PropertyDTO, Property>();
        }
    }
}
