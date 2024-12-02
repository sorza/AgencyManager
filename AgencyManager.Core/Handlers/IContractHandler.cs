using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IContractHandler
    {
        Task<Response<ContractService?>> CreateAsync(CreateContractServiceRequest request);
        Task<Response<ContractService?>> DeleteAsync(DeleteContractServiceRequest request);
        Task<PagedResponse<List<ContractService>?>> GetAllAsync(GetAllContractsByAgencyRequest request);
        Task<Response<ContractService?>> UpdateAsync(UpdateContractServiceRequest request);
        Task<Response<ContractService?>> GetByIdAsync(GetContractByIdRequest request);
    }
}