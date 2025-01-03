using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities.ValueObjects;
using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Responses;

namespace AgencyManager.Web.Handlers
{
    public class AddressHandler : IAddressHandler
    {
        public Task<Response<Address>> CreateAsync(CreateAddressRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Address>> UpdateAsync(UpdateAddressRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
