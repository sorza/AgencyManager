using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Locality;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface ILocalityHandler
    {
        Task<Response<Locality>> CreateAsync (CreateLocalityRequest request);
        Task<Response<Locality>> DeleteAsync (DeleteLocalityRequest request); 
        Task<PagedResponse<List<Locality>?>> GetAllAsync (GetAllLocalitiesRequest request);
        Task<Response<Locality>> GetByIdAsync(GetLocalityByIdRequest request);
        Task<Response<Locality>> UpdateAsync (UpdateLocalityRequest request);
    }
}