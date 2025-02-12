using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Account;
using AgencyManager.Core.Requests.Employee;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Web.Components.Identity
{
    public partial class CreateUserDialogForm : ComponentBase
    {
        #region Parameters        

        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = new();
        [Parameter] public UpdateEmployeeRequest InputModel { get; set; } = null!;
        #endregion

        #region Services
        [Inject] IAccountHandler AccountHandler { get; set; } = null!;
        [Inject] IEmployeeHandler EmployeeHandler { get; set; } = null!;
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        #endregion

        #region Properties
        public RegisterRequest UserRequest { get; set; } = new();
        #endregion

        #region Actions
        public async Task Submit()
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(UserRequest);

            bool isValid = Validator.TryValidateObject(UserRequest, context, validationResults, true);

            if (isValid)
            {                
                var result = await AccountHandler.RegisterAsync(UserRequest);

                if (result.IsSuccess)
                {                    
                    InputModel.UserLogin = UserRequest.Email;
                    
                    await EmployeeHandler.UpdateAsync(InputModel);
                    MudDialog.Close(DialogResult.Ok(InputModel));

                    Snackbar.Add("Usuário criado com sucesso!", Severity.Success);
                }
                else
                {
                    Snackbar.Add(result.Message!, Severity.Error);
                }
            }
        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }
        #endregion
    }
}
