using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IAgencyHandler
    {
        Task<Response<Agency>> CreateAsync(CreateAgencyRequest request);
        Task<Response<Agency>> DeleteAsync(DeleteAgencyRequest request);
        Task<Response<Agency>> GetByIdAsync(GetAgencyByIdRequest request);
        Task<PagedResponse<List<Agency>?>> GetAllAsync(GetAllAgenciesRequest request);
        Task<Response<Agency>> UpdateAsync(UpdateAgencyRequest request);
    }
}