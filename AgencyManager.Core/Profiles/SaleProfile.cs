using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Sale;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<CreateSaleRequest, Sale>();
            CreateMap<UpdateSaleRequest, Sale>();
        }
    }
}
