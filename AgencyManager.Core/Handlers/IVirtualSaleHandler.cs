using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.VirtualSale;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IVirtualSaleHandler
    {
        Task<Response<VirtualSale>> CreateAsync (CreateVirtualSaleRequest request);
        Task<Response<VirtualSale>> UpdateAsync (UpdateVirtualSaleRequest request);
        Task<Response<VirtualSale>> DeleteAsync (DeleteVirtualSaleRequest request);
        Task<Response<VirtualSale>> GetByIdAsync(GetVirtualSalesByIdRequest request);
        Task<PagedResponse<List<VirtualSale>?>> GetAllByCashIdAsync (GetVirtualSalesByCashIdRequest request);
    }
}