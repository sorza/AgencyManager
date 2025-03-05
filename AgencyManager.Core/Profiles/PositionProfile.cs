using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses.DTOs;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<CreatePositionRequest, Position>();
            CreateMap<UpdatePositionRequest, Position>();
            CreateMap<Position, PositionDto>();
        }
    }
}
