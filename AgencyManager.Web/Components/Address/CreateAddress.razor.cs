using AgencyManager.Core.Requests.Address;
using Microsoft.AspNetCore.Components;

namespace AgencyManager.Web.Components.Address
{
    public partial class CreateAddressComponent : ComponentBase
    {
        [Parameter]
        public CreateAddressRequest AddressModel { get; set; } = new();
    }
}
