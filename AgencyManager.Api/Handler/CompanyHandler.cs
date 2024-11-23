using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class CompanyHandler(AppDbContext context, IMapper mapper) : ICompanyHandler
    {
        public async Task<Response<Company>> CreateAsync(CreateCompanyRequest request)
        {
            #region 01. Validar requisição

            var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            string errors = string.Empty;

            if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                return new Response<Company>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

            #endregion

            #region 02. Mapear propriedades e criar empresa
            try
            {
                var company = mapper.Map<Company>(request);

                await context.Companies.AddAsync(company);
                await context.SaveChangesAsync();

                return new Response<Company>(company, 201, "Empresa cadastrada com sucesso.");
            }
            catch
            {
                return new Response<Company>(null, 500, "Não foi possível cadastrar empresa");
            }
            #endregion
        }

        public async Task<Response<Company>> DeleteAsync(DeleteCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<Company>?>> GetAllAsync(GetAllCompaniesRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Company>> UpdateAsync(UpdateCompanyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
