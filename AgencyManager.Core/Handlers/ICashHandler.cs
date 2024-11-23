using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface ICashHandler
    {
        Task<Response<Cash?>> CreateAsync(CreateCashRequest request);        
        Task<Response<Cash?>> GetByIdAsync(GetCashByIdRequest request);
        Task<Response<Cash?>> UpdateAsync(UpdateCashRequest request);
        Task<Response<Cash?>> DeleteAsync(DeleteCashRequest request);
        Task<PagedResponse<List<Cash>?>> GetByAgencyByPeriodAsync(GetCashsByAgencyByPeriodRequest request);
        Task<PagedResponse<List<Cash>?>> GetByUserByPeriodAsync(GetCashsByUserRequest request);
    }
}