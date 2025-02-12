using AgencyManager.Core.Requests.Contact;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Web.Components.Contact.DialogForm
{
    public partial class CreateContactDialogForm : ComponentBase
    {
        #region Parameters        

        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = new();
        [Parameter] public int CompanyId { get; set; }
        #endregion

        #region Properties
        public CreateContactRequest Contact { get; set; } = new();

        #endregion

        #region Overrides
        protected override void OnInitialized()
        {
            Contact.ContactType = Core.Enums.EContactType.Celular;
            Contact.CompanyId = CompanyId;
        }
        #endregion

        #region Actions
        public void Submit()
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(Contact);

            bool isValid = Validator.TryValidateObject(Contact, context, validationResults, true);

            if (isValid)
            {
                MudDialog.Close(DialogResult.Ok(Contact));
            }           
        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }
        #endregion
    }
}
