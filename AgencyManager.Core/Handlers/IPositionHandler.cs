using AgencyManager.Core.DTOs;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IPositionHandler
    {
        Task<Response<PositionDto?>> CreateAsync (CreatePositionRequest request);
        Task<Response<PositionDto?>> UpdateAsync (UpdatePositionRequest request);
        Task<Response<PositionDto?>> DeleteAsync (DeletePositionRequest request);
        Task<Response<PositionDto?>> GetByIdAsync(GetPositionByIdRequest request);
        Task<PagedResponse<List<PositionDto>?>> GetAllByAgencyIdAsync(GetPositionsByAgencyIdRequest request);
    }
}