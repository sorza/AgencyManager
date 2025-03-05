using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.Entities.ValueObjects;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses.DTOs;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {

            CreateMap<CreateContractServiceRequest, ContractService>()
                 .ForMember(dest => dest.NfeData, opt => opt.MapFrom(src => src.NfeData));

            CreateMap<UpdateContractServiceRequest, ContractService>()
            .ForMember(dest => dest.NfeData, opt => opt.MapFrom(src => src.NfeData))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.HasValue ? src.StartDate.Value : DateTime.MinValue));

            CreateMap<ContractService, ContractDto>();
        }
    }
}
