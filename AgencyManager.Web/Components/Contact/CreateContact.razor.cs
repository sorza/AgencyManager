using AgencyManager.Core.Requests.Contact;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Web.Components.Contact
{
    public class CreateContactComponent : ComponentBase
    {
        #region Parameter
        [Parameter]
        public IList<CreateContactRequest> Contacts { get; set; } = [];
        #endregion
        
        #region Properties
        public CreateContactRequest ContactModel { get; set; } = new();   

        #endregion

        #region Services
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        #endregion

        #region Overrides
        protected override void OnInitialized()
        {
            ContactModel.ContactType = Core.Enums.EContactType.Celular;
        }
        #endregion

        #region Public Methods
        public void RemoveContact(CreateContactRequest contact)
        {
            Contacts.Remove(contact);
            StateHasChanged();
        }
        public void AddContact()
        {
            if (IsValid(ContactModel))
            {
                var contact = new CreateContactRequest
                {
                    ContactType = ContactModel.ContactType,
                    Description = ContactModel.Description,
                    Departament = ContactModel.Departament,
                };

                Contacts.Add(contact);
            }
            else
            {
                Snackbar.Add("Contato inválido.", Severity.Error);
            }
            StateHasChanged();
        }
        #endregion

        #region Private Methods
        private bool IsValid(CreateContactRequest contact)
        {
            var validationContext = new ValidationContext(contact, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(contact, validationContext, validationResults, true))
                return false;
            return true;
        }
        #endregion

    }
}
