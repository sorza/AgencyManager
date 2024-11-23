using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Handler
{
    public class CashHandler : ICashHandler
    {
        public Task<Response<Cash?>> CreateAsync(CreateCashRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Cash?>> DeleteAsync(DeleteCashRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Cash>?>> GetByAgencyByPeriodAsync(GetCashsByAgencyByPeriodRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Cash?>> GetByIdAsync(GetCashByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Cash>?>> GetByUserByPeriodAsync(GetCashsByUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Cash?>> UpdateAsync(UpdateCashRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
