using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IPositionHandler
    {
        Task<Response<Position?>> CreateAsync (CreatePositionRequest request);
        Task<Response<Position?>> UpdateAsync (UpdatePositionRequest request);
        Task<Response<Position?>> DeleteAsync (DeletePositionRequest request);
        Task<Response<Position?>> GetByIdAsync(GetPositionByIdRequest request);
        Task<PagedResponse<List<Position>?>> GetAllByAgencyIdAsync(GetPositionsByAgencyIdRequest request);
    }
}