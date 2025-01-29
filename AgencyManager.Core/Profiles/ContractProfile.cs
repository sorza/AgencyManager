using AgencyManager.Core.DTOs;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.Entities.ValueObjects;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.ContractService;
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
                .ForMember(dest => dest.NfeData, opt => opt.MapFrom(src => src.NfeData));

            CreateMap<ContractService, ContractDto>();
        }
    }
}
