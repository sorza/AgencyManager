using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Position;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AgencyManager.Web.Pages.Positions
{
    public partial class CreatePositionPage : ComponentBase
    {
        #region Parameters
        [Parameter] public string Id { get; set; } = string.Empty;

        #endregion
        #region Properties

        public bool IsBusy { get; set; } = false;
        public CreatePositionRequest InputModel { get; set; } = new();    

        #endregion

        #region Services
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        [Inject] NavigationManager NavigationManager { get; set; } = null!;
        [Inject] IPositionHandler Handler { get; set; } = null!;

        #endregion
        
        #region Overrides
        protected override void OnInitialized()
        {
            try
            {
                InputModel.AgencyId = int.Parse(Id);
            }
            catch
            {
                Snackbar.Add("Agência Inválida", Severity.Error);
            }
        }

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.CreateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message!, Severity.Success);
                    NavigationManager.NavigateTo($"/cargos/{Id}");
                }
                else
                {
                    Snackbar.Add(result.Message!, Severity.Error);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
