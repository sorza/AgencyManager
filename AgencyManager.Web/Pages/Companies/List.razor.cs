using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AgencyManager.Web.Pages.Companies
{
    public partial class ListCompaniesPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public List<CompanyDto> Companies { get; set; } = [];
        public string SearchTerm { get; set; } = string.Empty;

        #endregion
        
        #region Services
        [Inject] public ISnackbar Snackbar { get; set; } = null!;
        [Inject] public ICompanyHandler Handler { get; set; } = null!;
        [Inject] public IDialogService DialogService { get; set; } = null!;

        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;

            try
            {
                var request = new GetAllCompaniesRequest();
                var result = await Handler.GetAllAsync(request);

                if (result.IsSuccess)
                    Companies = result.Data ?? [];
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

        public Func<CompanyDto, bool> Filter => company =>
        {
            if (string.IsNullOrEmpty(SearchTerm))
                return true;

            if (company.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (company.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (company.TradingName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        public async void OnDeleteButtonClickedAsync(int id, string description)
        {
            var result = await DialogService.ShowMessageBox(
                "ATENÇÃO",
                $"Ao prosseguir a empresa {description} será excluída permanentemente. Esta é uma ação irreversível! Deseja continuar?",
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
                await Handler.DeleteAsync(new DeleteCompanyRequest { Id = id });
                Companies.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Empresa {description} excluída com sucesso!", Severity.Success);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message!, Severity.Error);
            }
        }

        #endregion
    }
}
