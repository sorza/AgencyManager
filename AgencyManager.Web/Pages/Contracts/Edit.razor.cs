using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Requests.Nfe;
using AgencyManager.Core.Responses.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Web.Pages.Contracts
{
    public partial class ContractsEditPage : ComponentBase
    {
        #region Parameters
        [Parameter] public string Id { get; set; } = string.Empty;

        #endregion

        #region Properties
        public bool IsBusy { get; set; } = false;
        public UpdateContractServiceRequest InputModel { get; set; } = new();
        public CompanyDto Company { get; set; } = new();

        #endregion

        #region Services
        [Inject] public IContractHandler ContractHandler { get; set; } = null!;
        [Inject] public IAgencyHandler AgencyHandler { get; set; } = null!;
        [Inject] public ICompanyHandler CompanyHandler { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;
        [Inject] public NavigationManager Navigation { get; set; } = null!;

        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {            
            IsBusy = true;
           
            try
            {
                #region 01. Validar contrato
                var request = new GetContractByIdRequest { Id = Convert.ToInt32(Id) };
                var result = await ContractHandler.GetByIdAsync(request);

                if(result.Data is null)
                {
                    Snackbar.Add("Contrato inválido!", Severity.Error);
                    Navigation.NavigateTo("/agencias");
                    return;
                }

                InputModel.Id = Convert.ToInt32(Id);

                #endregion

                #region 02. Carregar dados

                InputModel.Active = result.Data.Active;
                InputModel.AgencyId = result.Data.AgencyId;
                InputModel.CompanyId = result.Data.CompanyId;
                InputModel.ServiceType = result.Data.ServiceType;
                InputModel.Comission = result.Data.Comission;
                InputModel.StartDate = result.Data.StartDate;
                InputModel.EndDate = result.Data.EndDate;
                InputModel.DailyPayment = result.Data.DailyPayment;
                InputModel.Boleto = result.Data.Boleto;
                InputModel.DailyComission = result.Data.DailyComission;
                InputModel.Nfe = result.Data.Nfe;

                if(result.Data.NfeData is not null)
                {
                    InputModel.NfeData = new UpdateNfeDataRequest
                    {
                        Address = new()
                        {
                            City = result.Data.NfeData.City,
                            Complement = result.Data.NfeData.Complement,
                            Neighborhood = result.Data.NfeData.Neighborhood,
                            Number = result.Data.NfeData.Number,
                            State = result.Data.NfeData.State,
                            Street = result.Data.NfeData.Street,
                            ZipCode = result.Data.NfeData.ZipCode
                        },
                        Cnpj = result.Data.NfeData.Cnpj,
                        Ie = result.Data.NfeData.Ie,
                        Name = result.Data.NfeData.Name
                    };
                }

                var response = await CompanyHandler.GetByIdAsync(new GetCompanyByIdRequest { Id = InputModel.CompanyId });
                Company = response.Data!;

                #endregion
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
                Navigation.NavigateTo("/agencias");
            }
            finally
            {
                IsBusy = false;
            }      
        }
        #endregion

        #region Methods
        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                if (InputModel.Nfe)
                {                   
                    bool nfeDataIsValid = Validator.TryValidateObject(
                        InputModel.NfeData,
                        new ValidationContext(InputModel.NfeData),
                        new List<ValidationResult>(), 
                        true);

                    bool enderecoIsValid = Validator.TryValidateObject(
                        InputModel.NfeData.Address,
                        new ValidationContext(InputModel.NfeData.Address),
                        new List<ValidationResult>(),
                        true);

                    if (nfeDataIsValid is false || enderecoIsValid is false)
                    {
                        Snackbar.Add("Preencha corretamente os dados para emissao da Nf-e.", Severity.Error);
                        return;
                    }
                }
                
                var result = await ContractHandler.UpdateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message!, Severity.Success);
                    Navigation.NavigateTo($"/contratos/{InputModel.AgencyId}");
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

        public void ClearNfeData() => InputModel.NfeData = new();

        public void ChangeState()
        {
            InputModel.Active = !InputModel.Active;

            if (InputModel.Active is true)
            {
                InputModel.EndDate = null;
            }
            else
            {
                if (InputModel.EndDate is null)
                {
                    InputModel.EndDate = DateTime.Now;
                }
            }
        }
        #endregion
    }
}
