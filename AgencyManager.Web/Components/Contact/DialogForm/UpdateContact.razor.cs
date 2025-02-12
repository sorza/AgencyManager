using AgencyManager.Core.DTOs;
using AgencyManager.Core.Requests.Contact;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AgencyManager.Web.Components.Contact.DialogForm
{
    public partial class UpdateContactDialogForm : ComponentBase
    {
        #region Parameters        

        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = new();
        [Parameter] public ContactDto Contact { get; set; } = null!;
        
        #endregion

        #region Properties
        public UpdateContactRequest InputModel { get; set; } = new();

        #endregion

        #region Overrides
        protected override void OnInitialized()
        {
            InputModel.ContactType = Core.Enums.EContactType.Celular;
            InputModel.Id = Contact.Id;           
            InputModel.ContactType = Contact.ContactType;
            InputModel.Description = Contact.Description;
            InputModel.Departament = Contact.Departament;
            InputModel.Responsible = Contact.Responsible;
        }
        #endregion

        #region Actions
        public void Submit()
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(InputModel);

            bool isValid = Validator.TryValidateObject(InputModel, context, validationResults, true);

            if (isValid)
            {
                MudDialog.Close(DialogResult.Ok(InputModel));
            }           
        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }
        #endregion
    }
}
