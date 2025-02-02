using AgencyManager.Core.Requests.Contact;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Web.Components.Contact
{
    public partial class UpdateContactComponent : ComponentBase
    {
        #region Parameter
        [Parameter]
        public IList<UpdateContactRequest>? Contacts { get; set; }
        #endregion

        #region Properties
        public UpdateContactRequest Contact { get; set; } = new();
        public bool IsEditing { get; set; } = false;
        public UpdateContactRequest SwapContact { get; set; } = new();
        #endregion
        
        #region Services
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        #endregion

        #region Overrides
        protected override void OnInitialized()
        {
            Contact.ContactType = Core.Enums.EContactType.Celular;
        }

        #endregion

        #region Public Methods
        public void OnDeleteButtonClicked(UpdateContactRequest contact)
        {
            if (contact is not null)                     
                if (Contacts is { } contacts && contacts.Contains(contact))  
                    Contacts.Remove(contact);                
        }       
        public void OnEditButtonClicked(UpdateContactRequest contact)
        {
            if (contact is not null)
            {               
                Contact.Description = contact.Description;
                Contact.Departament = contact.Departament;                
                Contact.ContactType = contact.ContactType;
                Contact.AgencyId = contact.AgencyId;
                Contact.CompanyId = contact.CompanyId;
                Contact.EmployeeId = contact.EmployeeId;

                SwapContact = contact;
                IsEditing = true;
            }
        }
        public void OnAddButtonClicked()
        {
            if (IsValid(Contact))
            {
                var contact = new UpdateContactRequest
                {
                    ContactType = Contact.ContactType,
                    Description = Contact.Description,
                    Departament = Contact.Departament,
                };

                Contacts?.Add(contact);
                Contact.Description = string.Empty;
                Contact.Departament = string.Empty;

                if (IsEditing)
                {
                    OnDeleteButtonClicked(SwapContact);
                    IsEditing = false;
                }                
            }
            else
            {
                Snackbar.Add("Contato inválido.", Severity.Error);
            }
            StateHasChanged();
        }

        #endregion

        #region PrivateMethods
        private bool IsValid(UpdateContactRequest contact)
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
