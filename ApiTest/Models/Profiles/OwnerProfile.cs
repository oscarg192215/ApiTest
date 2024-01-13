using ApiTest.Models.DTO;
using AutoMapper;

namespace ApiTest.Models.Profiles
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerDTO>();
            CreateMap<OwnerDTO, Owner>();
        }
    }
}
