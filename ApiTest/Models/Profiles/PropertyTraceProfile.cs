using ApiTest.Models.DTO;
using AutoMapper;

namespace ApiTest.Models.Profiles
{
    public class PropertyTraceProfile : Profile
    {
        public PropertyTraceProfile()
        {
            CreateMap<PropertyTrace, PropertyTraceDTO>();
            CreateMap<PropertyTraceDTO, PropertyTrace>();
        }
    }
}
