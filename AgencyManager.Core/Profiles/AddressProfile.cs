using AgencyManager.Core.Models.Entities.ValueObjects;
using AgencyManager.Core.Requests.Address;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressRequest, Address>();
            CreateMap<UpdateAddressRequest, Address>();
            CreateMap<Address, UpdateAddressRequest>();
        }        
    }
}
