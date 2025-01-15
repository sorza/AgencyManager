using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
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
        [Inject] IAgencyHandler AgencyHandler { get; set; } = null!;

        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {                 
            try
            {
                InputModel.AgencyId = int.Parse(Id);
            
                var request = new GetAgencyByIdRequest { Id = InputModel.AgencyId };
                var result = await AgencyHandler.GetByIdAsync(request);
                if (result.Data is null)
                {
                    Snackbar.Add("Agência não encontrada", Severity.Error);
                    NavigationManager.NavigateTo("/agencias");
                }

                //Todo: Verificar se o usuário tem permissão para criar um cargo nessa agência
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
