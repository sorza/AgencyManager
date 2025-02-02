using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Requests.Employee;
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
        public UpdateEmployeeRequest InputModel { get; set; } = new();       
        public AgencyDto Agency { get; set; } = new();       

        #endregion

        #region Services
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        [Inject] NavigationManager NavigationManager { get; set; } = null!;
        [Inject] IEmployeeHandler Handler { get; set; } = null!;
        [Inject] IAgencyHandler AgencyHandler { get; set; } = null!;

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
                    InputModel = new UpdateEmployeeRequest
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

                    var agencyrequest = new GetAgencyByIdRequest { Id = InputModel.AgencyId };
                    var resultAgency = await AgencyHandler.GetByIdAsync(agencyrequest);
                    Agency = resultAgency.Data!;                  
                   
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
                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(InputModel.Address);

                bool addressIsValid = Validator.TryValidateObject(InputModel.Address, context, validationResults, true);

                if (addressIsValid == false)
                {
                    Snackbar.Add("Endereço inválido.", Severity.Error);
                }
                else
                {
                    var result = await Handler.UpdateAsync(InputModel);
                    if (result.IsSuccess)
                    {
                        Snackbar.Add(result.Message!, Severity.Success);
                        NavigationManager.NavigateTo($"/funcionarios/{InputModel.AgencyId}");
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
        public void ChangeState()
        {
            InputModel.Active = !InputModel.Active;

            if (InputModel.Active is true)
            {
                InputModel.DateDismiss = null;
            }
            else
            {
                if(InputModel.DateDismiss is null)
                {
                    InputModel.DateDismiss= DateTime.Now;
                }
            }
        }      
        
        #endregion
       
    }

}

