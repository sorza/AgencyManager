using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Web.Pages.Contracts
{
    public partial class ContractsCreatePage : ComponentBase
    {
        #region Parameters
        [Parameter] public string Id { get; set; } = string.Empty;

        #endregion

        #region Properties
        public bool IsBusy { get; set; } = false;
        public CreateContractServiceRequest InputModel { get; set; } = new();
        public IList<CompanyDto> Companies { get; set; } = [];

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
            #region 01. Verifica se a agência é válida
            try
            {
                IsBusy = true;

                InputModel.AgencyId = int.Parse(Id);

                var agencyRequest = new GetAgencyByIdRequest { Id = InputModel.AgencyId };
                var agencyResult = await AgencyHandler.GetByIdAsync(agencyRequest);

                if (agencyResult.Data is null)
                {
                    Snackbar.Add("Agência não encontrada", Severity.Error);
                    Navigation.NavigateTo("/agencias");
                    return;
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
                Navigation.NavigateTo($"/agencias");
            }
            finally
            {
                IsBusy = false;
            }
            #endregion

            #region 02. Carrega as empresas
            var request = new GetAllCompaniesRequest();
            var result = await CompanyHandler.GetAllAsync(request);

            if (result.Data is not null)
            {
                Companies = result.Data;
            }

            #endregion

            #region 03. Inicializar campos

            InputModel.CompanyId = Companies.First().Id;
            InputModel.Comission = 10;
            InputModel.ServiceType = Core.Enums.EServiceType.Ticket;
            InputModel.StartDate = DateTime.Now;
            OnCompanySelected();
            #endregion

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

                var result = await ContractHandler.CreateAsync(InputModel);

                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message!, Severity.Success);
                    Navigation.NavigateTo($"/contratos/{Id}");
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
        public void OnCompanySelected()
        {
            var company = Companies.FirstOrDefault(x => x.Id == InputModel.CompanyId);

            if (company is not null)
            {
                InputModel.NfeData.Name = company.Name;
                InputModel.NfeData.Cnpj = company.Cnpj;

                InputModel.NfeData.Address.ZipCode = company.Address.ZipCode;
                InputModel.NfeData.Address.Neighborhood = company.Address.Neighborhood;
                InputModel.NfeData.Address.City = company.Address.City;
                InputModel.NfeData.Address.State = company.Address.State;
                InputModel.NfeData.Address.Street = company.Address.Street;
                InputModel.NfeData.Address.Number = company.Address.Number;
                InputModel.NfeData.Address.Complement = company.Address.Complement ?? string.Empty;
            }
        }
        public void ClearNfeData()
        {
            InputModel.NfeData.Name = string.Empty;
            InputModel.NfeData.Cnpj = string.Empty;

            InputModel.NfeData.Address.ZipCode = string.Empty;
            InputModel.NfeData.Address.Neighborhood = string.Empty;
            InputModel.NfeData.Address.City = string.Empty;
            InputModel.NfeData.Address.State = string.Empty;
            InputModel.NfeData.Address.Street = string.Empty;
            InputModel.NfeData.Address.Number = string.Empty;
            InputModel.NfeData.Address.Complement = string.Empty;
        }
        #endregion
    }
}
