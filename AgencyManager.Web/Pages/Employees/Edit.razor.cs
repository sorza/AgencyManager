using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Web.Pages.Employees
{
    public partial class EmployeeEditPage : ComponentBase
    {
        #region Parameters
        [Parameter] public string Id { get; set; } = string.Empty;

        #endregion

        #region Properties

        public bool IsBusy { get; set; } = false;
        public UpdateEmployeeRequest EmployeeInputModel { get; set; } = new();
        public UpdateContactRequest ContactInputModel { get; set; } = new();
        public AgencyDto Agency { get; set; } = new();
        public MudTextField<string>? CepInput { get; set; }

        #endregion

        #region Services
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        [Inject] NavigationManager NavigationManager { get; set; } = null!;
        [Inject] IEmployeeHandler Handler { get; set; } = null!;
        [Inject] IAgencyHandler AgencyHandler { get; set; } = null!;
        [Inject] IContactHandler ContactHandler { get; set; } = null!;
        [Inject] IDialogService DialogService { get; set; } = null!;

        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            try
            {
                var request = new GetEmployeeByIdRequest { Id = int.Parse(Id) };
                var result = await Handler.GetByIdAsync(request);

                if (result.Data is null)
                {
                    Snackbar.Add("Colaborador não encontrado", Severity.Error);
                    NavigationManager.NavigateTo($"/agencias");
                }
                else
                {
                    EmployeeInputModel = new UpdateEmployeeRequest
                    {
                        Id = result.Data.Id,
                        Name = result.Data.Name,
                        AgencyId = result.Data.AgencyId,
                        Address = new()
                        {
                            ZipCode = result.Data.Address!.ZipCode,
                            City = result.Data.Address!.City,
                            Complement = result.Data.Address!.Complement,
                            Neighborhood = result.Data.Address!.Neighborhood,
                            Number = result.Data.Address!.Number,
                            State = result.Data.Address!.State,
                            Street = result.Data.Address!.Street
                        },

                        BirthDay = result.Data.BirthDay,
                        Cpf = result.Data.Cpf,
                        Rg = result.Data.Rg,
                        PositionId = result.Data.PositionId,
                        DateHire = result.Data.DateHire,
                        DateDismiss = result.Data.DateDismiss,
                        Active = result.Data.Active,

                        Contacts = result.Data.Contacts?.Select(c => new UpdateContactRequest
                        {
                            Id = c.Id,
                            Description = c.Description,
                            Departament = c.Departament,
                            ContactType = c.ContactType
                        }).ToList()
                    };

                    var agencyrequest = new GetAgencyByIdRequest { Id = EmployeeInputModel.AgencyId };
                    var resultAgency = await AgencyHandler.GetByIdAsync(agencyrequest);
                    Agency = resultAgency.Data!;
                    
                    ContactInputModel.ContactType = Core.Enums.EContactType.Celular;
                }
            }
            catch
            {
                Snackbar.Add("Colaborador Inválido", Severity.Error);
                NavigationManager.NavigateTo("/agencias");
            }
        }

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.UpdateAsync(EmployeeInputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message!, Severity.Success);
                    NavigationManager.NavigateTo($"/funcionarios/{EmployeeInputModel.AgencyId}");
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
            finally
            {
                IsBusy = false;
            }
        }

        public void ChangeState()
        {
            EmployeeInputModel.Active = !EmployeeInputModel.Active;

            if (EmployeeInputModel.Active is true)
            {
                EmployeeInputModel.DateDismiss = null;
            }
            else
            {
                if(EmployeeInputModel.DateDismiss is null)
                {
                    EmployeeInputModel.DateDismiss= DateTime.Now;
                }
            }
        }
        
        public async void OnDeleteButtonClickedAsync(UpdateContactRequest contact)
        {
            var result = await DialogService.ShowMessageBox(
                "ATENÇÃO",
                $"Ao prosseguir o contato {contact.Description} será excluído permanentemente. Esta é uma ação irreversível! Deseja continuar?",
                yesText: "Excluir",
                noText: "Cancelar");

            if (result is true)
                await OnDeleteAsync(contact);

            StateHasChanged();
        }
        public async Task OnDeleteAsync(UpdateContactRequest contact)
        {
            if (contact.Id != 0)
            {
                try
                {
                    await ContactHandler.DeleteAsync(new DeleteContactRequest { Id = contact.Id });

                    Snackbar.Add($"Contato excluído com sucesso!", Severity.Success);
                }
                catch (Exception ex)
                {
                    Snackbar.Add(ex.Message!, Severity.Error);
                }
            }
            EmployeeInputModel.Contacts?.RemoveAll(x => x.Id == contact.Id);
        }
        public void AddContact()
        {
            if (IsValid(ContactInputModel))
            {
                var contact = new UpdateContactRequest
                {
                    ContactType = ContactInputModel.ContactType,
                    Description = ContactInputModel.Description,
                    Departament = ContactInputModel.Departament,
                };

                EmployeeInputModel.Contacts?.Add(contact);
            }
            else
            {
                Snackbar.Add("Contato inválido.", Severity.Error);
            }
            StateHasChanged();
        }
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

