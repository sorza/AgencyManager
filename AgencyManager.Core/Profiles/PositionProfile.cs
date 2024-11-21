﻿using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<CreatePositionRequest, Position>();
            CreateMap<CreatePositionRequest, Position>();
        }
    }
}