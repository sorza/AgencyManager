using AgencyManager.Core.Models.ValueObjects;
using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IAddressHandler
    {
        Task<Response<Address>> CreateAsync(CreateAddressRequest request);
        Task<Response<Address>> UpdateAsync(UpdateAddressRequest request);        
    }
}