using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AgencyManager.Web.Pages.Agencies
{
    public partial class ListAgenciesPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public List<AgencyDto> Agencies { get; set; } = [];
        public string SearchTerm { get; set; } = string.Empty;

        #endregion

        #region Services
        [Inject] public ISnackbar Snackbar { get; set; } = null!;
        [Inject] public IAgencyHandler Handler { get; set; } = null!;
        [Inject] public IDialogService DialogService { get; set; } = null!;

        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;

            try
            {
                var request = new GetAllAgenciesRequest();
                var result = await Handler.GetAllAsync(request);

                if(result.IsSuccess)
                    Agencies = result.Data ?? [];
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message!, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #region Methods

        public Func<AgencyDto, bool> Filter => agency =>
        {
            if(string.IsNullOrEmpty(SearchTerm))
                return true;

            if(agency.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (agency.Description.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (agency.Address.City.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        public async void OnDeleteButtonClickedAsync(int id, string description)
        {
            var result = await DialogService.ShowMessageBox(
                "ATENÇÃO",
                $"Ao prosseguir a agência {description} será excluída permanentemente. Esta é uma ação irreversível! Deseja continuar?",
                yesText: "Excluir",
                noText: "Cancelar");

            if (result is true)
                await OnDeleteAsync(id, description);

            StateHasChanged();
        }
        public async Task OnDeleteAsync(int id, string description)
        {
            try
            {
                await Handler.DeleteAsync(new DeleteAgencyRequest { Id = id });
                Agencies.RemoveAll(x=> x.Id == id);
                Snackbar.Add($"Agência {description} excluída com sucesso!", Severity.Success);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message!, Severity.Error);
            }
        }

        #endregion
    }
}
