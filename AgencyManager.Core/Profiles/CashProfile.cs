using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class CashProfile : Profile
    {
        public CashProfile()
        {
            CreateMap<CreateCashRequest, Cash>();
            CreateMap<UpdateCashRequest, Cash>();
        }
    }
}
