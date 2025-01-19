using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Position;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AgencyManager.Web.Pages.Positions
{
    public partial class EditPositionPage : ComponentBase
    {
        #region Parameters
        [Parameter] public string Id { get; set; } = string.Empty;

        #endregion

        #region Properties

        public bool IsBusy { get; set; } = false;
        public UpdatePositionRequest InputModel { get; set; } = new();

        #endregion

        #region Services
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        [Inject] NavigationManager NavigationManager { get; set; } = null!;
        [Inject] IPositionHandler Handler { get; set; } = null!;

        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            try
            {               
                var request = new GetPositionByIdRequest { Id = int.Parse(Id) };
                var result = await Handler.GetByIdAsync(request);

                if (result.Data is null)
                {
                    Snackbar.Add("Cargo não encontrado", Severity.Error);
                    NavigationManager.NavigateTo($"/agencias");
                }
                else
                {
                    InputModel = new UpdatePositionRequest
                    {
                        Id = result.Data.Id,
                        Description = result.Data.Description,
                        Responsabilities = result.Data.Responsabilities,
                        Salary = result.Data.Salary,
                        AgencyId = result.Data.AgencyId
                    };
                }
            }
            catch
            {
                Snackbar.Add("Agência Inválida", Severity.Error);
                NavigationManager.NavigateTo("/agencias");
            }
        }

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.UpdateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message!, Severity.Success);
                    NavigationManager.NavigateTo($"/cargos/{InputModel.AgencyId}");
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
