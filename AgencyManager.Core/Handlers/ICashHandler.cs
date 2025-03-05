using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;

namespace AgencyManager.Core.Handlers
{
    public interface ICashHandler
    {
        Task<Response<CashDto?>> CreateAsync(CreateCashRequest request);        
        Task<Response<CashDto?>> GetByIdAsync(GetCashByIdRequest request);
        Task<Response<CashDto?>> UpdateAsync(UpdateCashRequest request);
        Task<Response<CashDto?>> DeleteAsync(DeleteCashRequest request);
        Task<PagedResponse<List<CashDto>?>> GetByAgencyByPeriodAsync(GetCashsByAgencyByPeriodRequest request);
        Task<PagedResponse<List<CashDto>?>> GetByUserByPeriodAsync(GetCashsByUserByPeriodRequest request);
    }
}