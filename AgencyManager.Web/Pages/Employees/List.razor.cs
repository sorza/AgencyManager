using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Employee;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AgencyManager.Web.Pages.Employees
{
    public partial class EmployeeListPage : ComponentBase
    {
        #region Parameters
        [Parameter] public string Id { get; set; } = string.Empty;
        #endregion

        #region Properties
        public bool IsBusy { get; set; }
        public List<EmployeeDto>? Employees { get; set; } = [];
        public string SearchTerm { get; set; } = string.Empty;
        #endregion

        #region Services
        [Inject] public ISnackbar Snackbar { get; set; } = null!;
        [Inject] public IEmployeeHandler Handler { get; set; } = null!;
        [Inject] public IDialogService DialogService { get; set; } = null!;
        [Inject] public IAgencyHandler AgencyHandler { get; set; } = null!;
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;
        #endregion

        #region Overrides
     
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;

            try
            {
                var request = new GetAgencyByIdRequest { Id = Convert.ToInt32(Id) };
                var result = await AgencyHandler.GetByIdAsync(request);

                if(result is null)
                {
                    Snackbar.Add("Agência inválida", Severity.Error);
                    NavigationManager.NavigateTo("/agencias");
                }
               
                if(result!.Data!.Positions.Count() == 0)
                {
                    Snackbar.Add("Não há cargos cadastrados nesta agência. Não é possível gerenciar colaboradores sem cargos.", Severity.Error);
                    NavigationManager.NavigateTo($"/agencias/editar/{Id}");
                }
                
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
                NavigationManager.NavigateTo("/agencias");
            }

            try
            {
                var request = new GetAllEmployeesByAgencyIdRequest { AgencyId = Convert.ToInt32(Id) };
                var result = await Handler.GetAllByAgencyIdAsync(request);

                if (result.IsSuccess)
                    Employees = result.Data ?? [];
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
        public async void OnDeleteButtonClickedAsync(int id, string description)
        {
            var result = await DialogService.ShowMessageBox(
                "ATENÇÃO",
                $"Ao prosseguir o funcionário {description} será excluído permanentemente. Esta é uma ação irreversível! Deseja continuar?",
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
                await Handler.DeleteAsync(new DeleteEmployeeRequest { Id = id });
                Employees!.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Funcionário {description} excluído com sucesso!", Severity.Success);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message!, Severity.Error);
            }
        }

        public Func<EmployeeDto, bool> Filter => employee =>
        {
            if (string.IsNullOrEmpty(SearchTerm))
                return true;           

            if (employee.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (employee.Cpf.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
        #endregion
    }
}

