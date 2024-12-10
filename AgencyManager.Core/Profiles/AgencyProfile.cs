using AgencyManager.Core.DTOs;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    internal class AgencyProfile : Profile
    {
        public AgencyProfile()
        {
            CreateMap<CreateAgencyRequest, Agency>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));              

            CreateMap<UpdateAgencyRequest, Agency>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Agency, AgencyDto>();
        }
    }
}
