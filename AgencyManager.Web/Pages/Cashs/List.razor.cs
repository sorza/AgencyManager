using AgencyManager.Core.Handlers;
using AgencyManager.Core.Common.Extensions;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses.DTOs;
using AgencyManager.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AgencyManager.Web.Pages.Cashs
{
    public partial class ListCashsPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public string SearchTerm { get; set; } = string.Empty;
        public EmployeeDto Employee { get; set; } = new();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<CashDto> Cashs { get; set; } = [];
        #endregion

        #region Services
        [Inject] ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
        [Inject] IEmployeeHandler EmployeeHandler { get; set; } = null!;
        [Inject] NavigationManager NavigationManager { get; set; } = null!;
        [Inject] ICashHandler CashHandler { get; set; } = null!;
        [Inject] ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Overrides

        protected async override Task OnInitializedAsync()
        {
            try
            {
                IsBusy = true;

                var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                var request = new GetEmployeeByUsernameRequest { Username = authState.User.Identity!.Name! };

                var result = await EmployeeHandler.GetByUsernameAsync(request);

                if (result.Data is null)
                {
                    Snackbar.Add("Usuário Inválido.", Severity.Error);
                    NavigationManager.NavigateTo("/");
                    return;
                }

                StartDate = DateTime.Now.GetFirstDay();
                EndDate = DateTime.Now.GetLastDay();

                Employee = result.Data;

                await LoadCashs();

            }
            catch(Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
                return;
            }
            finally
            {
                IsBusy = false;
            }           
           
        }
        #endregion

        #region Methods
        
        public async void NewCash()
        {
            try
            {
                var request = new CreateCashRequest { AgencyId = Employee.AgencyId, Date = DateTime.Now.Date, StartValue = 0, EndValue = 0, UserId = Employee.UserLogin! };

                var result = await CashHandler.CreateAsync(request);

                if (result.Data is not null)
                {
                    Snackbar.Add(result.Message!, Severity.Success);        
                    
                    await LoadCashs();

                    StateHasChanged();
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
        }
      
        public async Task LoadCashs()
        {
            try
            {
                IsBusy = true;
                var cashRequest = new GetCashsByUserByPeriodRequest { UserId = Employee.UserLogin!, StartDate = StartDate, EndDate = EndDate };
                var cashResponse = await CashHandler.GetByUserByPeriodAsync(cashRequest);
                Cashs = cashResponse.Data ?? [];
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
