using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Web.Components.Contact;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AgencyManager.Web.Pages.Contacts
{
    public partial class ContactsPageList : ComponentBase
    {
        #region Services
        [Inject] public ICompanyHandler Handler { get; set; } = null!;
        [Inject] public IContactHandler ContactHandler { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;
        [Inject] public IDialogService DialogService { get; set; } = null!;
        #endregion

        #region Properties       
        public IList<CompanyDto> Companies { get; set; } = [];
        public List<ContactDto> Contacts { get; set; } = [];
        public CompanyDto Company { get; set; } = new();
        public CreateContactRequest Contact { get; set; } = new();
        public bool IsEditing { get; set; } = false;
        public string SearchTerm { get; set; } = string.Empty;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            var request = new GetAllCompaniesRequest
            {
                PageNumber = Core.Configuration.DefaultPageNumber,
                PageSize = Core.Configuration.DefaultPageSize
            };

            var result = await Handler.GetAllAsync(request);

            if (result.Data is null) return;
                  
            Companies = result.Data;            
        }

        #endregion

        #region Methods

        public async Task LoadContactsAsync()
        {
            try
            {
                var request = new GetContactsByCompanyId { CompanyId = Company.Id };
                var result = await ContactHandler.GetAllByCompanyAsync(request);

                if (result.Data is not null)
                    Contacts = result.Data;
            }
            catch 
            {
                Contacts = [];
            }
        }
        public async Task OpenCreateContactDialog()
        {
            if(Company.Id != 0)
            {
                var parameters = new DialogParameters { ["CompanyId"] = Company.Id };
                var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

                var dialog = DialogService.Show<Components.Contact.DialogForm.CreateContact>("NOVO CONTATO", parameters, options);
                var result = await dialog.Result;

                if (result is null) return;

                if (!result.Canceled)
                {
                    var contact = result.Data as CreateContactRequest;
                    await ContactHandler.CreateAsync(contact!);                    
                }

                await LoadContactsAsync();
            }            
        }
        public async Task OpenUpdateContactDialog(ContactDto contact)
        {
            if (contact.Id != 0)
            {
                var parameters = new DialogParameters { ["Contact"] = contact };
                var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

                var dialog = DialogService.Show<Components.Contact.DialogForm.UpdateContact>("ATUALIZAR CONTATO", parameters, options);
                var result = await dialog.Result;

                if (result is null) return;

                if (!result.Canceled)
                {
                    var contactUpdated = result.Data as UpdateContactRequest;
                    contactUpdated!.CompanyId = Company.Id;
                    await ContactHandler.UpdateAsync(contactUpdated!);
                }

                await LoadContactsAsync();
            }
        }

        public async void OnDeleteButtonClickedAsync(int id, string description)
        {
            var result = await DialogService.ShowMessageBox(
                "ATENÇÃO",
                $"Ao prosseguir o contato {description} será excluído permanentemente. Esta é uma ação irreversível! Deseja continuar?",
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
                await ContactHandler.DeleteAsync(new DeleteContactRequest { Id = id });
                Contacts.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Contato {description} excluído com sucesso!", Severity.Success);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message!, Severity.Error);
            }
        }
        public Func<ContactDto, bool> Filter => contact =>
        {
            if (string.IsNullOrEmpty(SearchTerm))
                return true;

            if (contact.Description.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (contact.Departament.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (contact.Responsible.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
        #endregion
    }
}
