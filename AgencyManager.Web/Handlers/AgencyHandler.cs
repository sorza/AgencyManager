using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;

namespace AgencyManager.Web.Handlers
{
    public class AgencyHandler : IAgencyHandler
    {
        public Task<Response<AgencyDto?>> CreateAsync(CreateAgencyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AgencyDto?>> DeleteAsync(DeleteAgencyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<AgencyDto>?>> GetAllAsync(GetAllAgenciesRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AgencyDto?>> GetByIdAsync(GetAgencyByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AgencyDto?>> UpdateAsync(UpdateAgencyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
