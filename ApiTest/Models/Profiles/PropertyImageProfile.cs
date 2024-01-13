using ApiTest.Models.DTO;
using AutoMapper;

namespace ApiTest.Models.Profiles
{
    public class PropertyImageProfile : Profile
    {
        public PropertyImageProfile()
        {
            CreateMap<PropertyImage, PropertyImageDTO>();
            CreateMap< PropertyImageDTO, PropertyImage>();
        }
    }
}
