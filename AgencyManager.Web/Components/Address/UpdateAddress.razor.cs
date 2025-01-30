using AgencyManager.Core.Requests.Address;
using Microsoft.AspNetCore.Components;

namespace AgencyManager.Web.Components.Address
{
    public partial class UpdateAddressComponent : ComponentBase
    {
        [Parameter]
        public UpdateAddressRequest AddressModel { get; set; } = new();
    }
}
