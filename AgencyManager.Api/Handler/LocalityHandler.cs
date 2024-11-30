using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Locality;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Handler
{
    public class LocalityHandler : ILocalityHandler
    {
        public Task<Response<Locality>> CreateAsync(CreateLocalityRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Locality>> DeleteAsync(DeleteLocalityRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Locality>?>> GetAllAsync(GetAllLocalitiesRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Locality>> GetByIdAsync(GetLocalityByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Locality>> UpdateAsync(UpdateLocalityRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
