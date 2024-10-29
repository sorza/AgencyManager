using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Sale;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface ISaleHandler
    {
        Task<Response<Sale>> CreateAsync (CreateSaleRequest request);
        Task<Response<Sale>> UpdateAsync (UpdateSaleRequest request);
        Task<Response<Sale>> DeleteAsync (DeleteSaleRequest request);
        Task<PagedResponse<List<Sale>?>> GetAllByCashAsync(GetSalesByCashRequest request);
    }
}