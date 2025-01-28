using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.ContractService;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AgencyManager.Web.Pages.Contracts
{
    public partial class ContractsListPage : ComponentBase
    {
        #region Parameters
        [Parameter] public string Id { get; set; } = string.Empty;
        #endregion        

        #region Properties
        public bool IsBusy { get; set; }
        public List<ContractDto>? Contracts { get; set; } = [];
        public string SearchTerm { get; set; } = string.Empty;
        #endregion

        #region Services
        [Inject] public ISnackbar Snackbar { get; set; } = null!;
        [Inject] public IContractHandler Handler { get; set; } = null!;
        [Inject] public IDialogService DialogService { get; set; } = null!;
        [Inject] public IAgencyHandler AgencyHandler { get; set; } = null!;
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;
        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;

            #region 01. Validar agência
            try
            {
                var request = new GetAgencyByIdRequest { Id = Convert.ToInt32(Id) };
                var result = await AgencyHandler.GetByIdAsync(request);

                if (result is null)
                {
                    Snackbar.Add("Agência inválida", Severity.Error);
                    NavigationManager.NavigateTo("/agencias");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
                NavigationManager.NavigateTo("/agencias");
            }
            #endregion

            #region 02. Buscar contratos
            try
            {
                var request = new GetAllContractsByAgencyRequest { AgencyId = Convert.ToInt32(Id) };
                var result = await Handler.GetByAgencyIdAsync(request);

                if (result.IsSuccess)
                    Contracts = result.Data ?? [];
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message!, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
            #endregion
        }
        #endregion

        #region Public Methods
        public async void OnDeleteButtonClickedAsync(int id, string description)
        {
            var result = await DialogService.ShowMessageBox(
                "ATENÇÃO",
                $"Ao prosseguir o contrato com a empresa {description} será excluído permanentemente. Esta é uma ação irreversível! Deseja continuar?",
                yesText: "Excluir",
                noText: "Cancelar");

            if (result is true)
                await OnDeleteAsync(id, description);

            StateHasChanged();
        }

        public Func<ContractDto, bool> Filter => contract =>
        {
            if (string.IsNullOrEmpty(SearchTerm))
                return true;

            if (contract.Company!.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
        #endregion

        #region Private Methods
        private async Task OnDeleteAsync(int id, string description)
        {
            try
            {
                await Handler.DeleteAsync(new DeleteContractServiceRequest { Id = id });
                Contracts!.RemoveAll(x => x.Id == id);
                Snackbar.Add($"O contrato com a empresa {description} foi excluído com sucesso!", Severity.Success);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message!, Severity.Error);
            }
        }
        #endregion
    }
}
