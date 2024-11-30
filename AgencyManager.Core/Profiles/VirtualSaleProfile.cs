using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.VirtualSale;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class VirtualSaleProfile : Profile
    {
        public VirtualSaleProfile()
        {
            CreateMap<CreateVirtualSaleRequest, VirtualSale>();
            CreateMap<UpdateVirtualSaleRequest, VirtualSale>();
        }
    }
}
