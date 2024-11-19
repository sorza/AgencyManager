using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;
using AutoMapper;

namespace AgencyManager.Api.Handler
{
    public class PositionHandler(AppDbContext context, IMapper mapper) : IPositionHandler
    {
        public Task<Response<Position>> CreateAsync(CreatePositionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Position>> DeleteAsync(DeletePositionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Position>?>> GetAllByAgencyIdAsync(GetPositionsByAgencyIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Position>> UpdateAsync(UpdatePositionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
