using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;

namespace AgencyManager.Core.Handlers
{
    public interface IContractHandler
    {
        Task<Response<ContractDto?>> CreateAsync(CreateContractServiceRequest request);
        Task<Response<ContractDto?>> DeleteAsync(DeleteContractServiceRequest request);
        Task<PagedResponse<List<ContractDto>?>> GetByAgencyIdAsync(GetAllContractsByAgencyRequest request);
        Task<Response<ContractDto?>> UpdateAsync(UpdateContractServiceRequest request);
        Task<Response<ContractDto?>> GetByIdAsync(GetContractByIdRequest request);
    }
}