using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Requests.Employee;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;


namespace AgencyManager.Web.Pages.Employees
{
    public partial class CreateEmployeePage : ComponentBase
    {
        #region Parameter
        [Parameter] public string Id { get; set; } = string.Empty;
        #endregion

        #region Properties
        public bool IsBusy { get; set; } = false;
        public CreateEmployeeRequest EmployeeInputModel { get; set; } = new();
        public CreateContactRequest ContactInputModel { get; set; } = new();
        public AgencyDto Agency { get; set; } = new();
        public MudTextField<string>? CepInput { get; set; }

        #endregion

        #region Services
        [Inject] public IAgencyHandler AgencyHandler { get; set; } = null!;
        [Inject] public IEmployeeHandler EmployeeHandler { get; set; } = null!;
        [Inject] public NavigationManager Navigation { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {          
            try
            {
                EmployeeInputModel.AgencyId = int.Parse(Id);

                var request = new GetAgencyByIdRequest { Id = EmployeeInputModel.AgencyId };
                var result = await AgencyHandler.GetByIdAsync(request);

                if (result.Data is null)
                {
                    Snackbar.Add("Agência não encontrada", Severity.Error);
                    Navigation.NavigateTo("/agencias");
                }

                Agency = result.Data!;

                if(Agency.Positions is null || !Agency.Positions.Any())
                {
                    Snackbar.Add("Agência sem cargos", Severity.Error);
                    Navigation.NavigateTo("/agencias");
                }

                EmployeeInputModel.PositionId = Agency.Positions!.First().Id;
                EmployeeInputModel.DateHire = DateTime.Now;
                EmployeeInputModel.BirthDay = DateTime.Now.AddYears(-18);
                ContactInputModel.ContactType = Core.Enums.EContactType.Celular;

            }
            catch
            {
                Snackbar.Add("Agência Inválida", Severity.Error);
                Navigation.NavigateTo("/agencias");
            }
        }       

        #endregion

        #region Methods
        public async Task OnValidSubmitAsync()
        {           
            IsBusy = true;

            try
            {
                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(EmployeeInputModel.Address);

                bool addressIsValid = Validator.TryValidateObject(EmployeeInputModel.Address, context, validationResults, true);                               

                if (addressIsValid == false)
                {
                    Snackbar.Add("Endereço inválido.", Severity.Error);      
                    CepInput?.FocusAsync();
                }
                else
                {
                    var result = await EmployeeHandler.CreateAsync(EmployeeInputModel);
                    if (result.IsSuccess)
                    {
                        Snackbar.Add(result.Message!, Severity.Success);
                        Navigation.NavigateTo($"/funcionarios/{Id}");
                    }
                    else
                    {
                        Snackbar.Add(result.Message!, Severity.Error);
                    }
                }
                
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

        public void RemoveContact(CreateContactRequest contact)
        {
            EmployeeInputModel.Contacts.Remove(contact);
            StateHasChanged();
        }
        public void AddContact()
        {
            if (IsValid(ContactInputModel))
            {
                var contact = new CreateContactRequest
                {
                    ContactType = ContactInputModel.ContactType,
                    Description = ContactInputModel.Description,
                    Departament = ContactInputModel.Departament,
                };

                EmployeeInputModel.Contacts.Add(contact);
            }
            else
            {
                Snackbar.Add("Contato inválido.", Severity.Error);
            }
            StateHasChanged();
        }
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
