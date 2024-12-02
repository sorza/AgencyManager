using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.ContractService;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<CreateContractServiceRequest, ContractService>();
            CreateMap<UpdateContractServiceRequest, ContractService>();
        }
    }
}
