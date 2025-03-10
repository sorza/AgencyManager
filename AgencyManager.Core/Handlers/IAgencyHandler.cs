using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;

namespace AgencyManager.Core.Handlers
{
    public interface IAgencyHandler
    {
        Task<Response<AgencyDto?>> CreateAsync(CreateAgencyRequest request);
        Task<Response<AgencyDto?>> DeleteAsync(DeleteAgencyRequest request);
        Task<Response<AgencyDto?>> GetByIdAsync(GetAgencyByIdRequest request);
        Task<PagedResponse<List<AgencyDto>?>> GetAllAsync(GetAllAgenciesRequest request);
        Task<Response<AgencyDto?>> UpdateAsync(UpdateAgencyRequest request);
    }
}