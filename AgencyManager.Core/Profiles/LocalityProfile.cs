using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Locality;
using AutoMapper;
namespace AgencyManager.Core.Profiles
{
    public class LocalityProfile : Profile
    {
        public LocalityProfile()
        {
            CreateMap<CreateLocalityRequest, Locality>();
            CreateMap<UpdateLocalityRequest, Locality>();
        }
    }
}
