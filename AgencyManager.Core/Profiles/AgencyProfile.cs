﻿using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses.DTOs;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    internal class AgencyProfile : Profile
    {
        public AgencyProfile()
        {
            CreateMap<CreateAgencyRequest, Agency>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.Contacts));

            CreateMap<UpdateAgencyRequest, Agency>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Agency, AgencyDto>();
        }
    }
}
