using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AgencyManager.Web.Components.Address
{
    public partial class CreateAddressComponent : ComponentBase
    {
        #region Parameters
        [Parameter]
        public CreateAddressRequest AddressModel { get; set; } = new();
        #endregion

        #region Services
        [Inject] ICepService CepService { get; set; } = null!;
        [Inject] ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods
        public async Task GetAddressAsync()
        {
            try
            {
                var result = await CepService.GetAddressByCepAsync(AddressModel.ZipCode);

                if (result.IsSuccess && result.Data is not null)
                {
                    AddressModel.Street = result.Data.Street;
                    AddressModel.City = result.Data.City;
                    AddressModel.State = result.Data.State;
                    AddressModel.Neighborhood = result.Data.Neighborhood;
                    AddressModel.Complement = result.Data.Complement;
                }
            }
            catch
            {
                AddressModel = new();
                Snackbar.Add("CEP inválido", Severity.Error);
            }
        }

        #endregion
    }
}
