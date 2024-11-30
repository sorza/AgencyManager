using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.VirtualSale;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Handler
{
    public class VirtualSaleHandler : IVirtualSaleHandler
    {
        public Task<Response<VirtualSale>> CreateAsync(CreateVirtualSaleRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<VirtualSale>> DeleteAsync(DeleteVirtualSaleRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<VirtualSale>?>> GetAllByCashIdAsync(GetVirtualSalesByCashIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<VirtualSale>> GetByIdAsync(GetVirtualSalesByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<VirtualSale>> UpdateAsync(UpdateVirtualSaleRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
