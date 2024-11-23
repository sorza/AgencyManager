using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class CompanyHandler(AppDbContext context, IMapper mapper) : ICompanyHandler
    {
        public async Task<Response<Company?>> CreateAsync(CreateCompanyRequest request)
        {
            #region 01. Validar requisição

            var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            string errors = string.Empty;

            if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                return new Response<Company?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

            #endregion

            #region 02. Mapear propriedades e criar empresa
            try
            {
                var company = mapper.Map<Company>(request);

                await context.Companies.AddAsync(company);
                await context.SaveChangesAsync();

                return new Response<Company?>(company, 201, "Empresa cadastrada com sucesso.");
            }
            catch
            {
                return new Response<Company?>(null, 500, "Não foi possível cadastrar empresa");
            }
            #endregion
        }
        public async Task<Response<Company?>> DeleteAsync(DeleteCompanyRequest request)
        {
            try
            {
                #region 01. Buscar empresa
                var company = await context.Companies
                  .Include(a => a.Address)
                  .Include(a => a.Contacts)
                  .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (company is null)
                    return new Response<Company?>(null, 404, "Empresa não encontrada");

                #endregion

                #region 02. Remover contatos
                if (company.Contacts is not null)
                    context.Contacts.RemoveRange(company.Contacts);

                #endregion               

                #region 03. Remover empresa
                context.Companies.Remove(company);

                #endregion

                #region 04. Salvar Alterações
                await context.SaveChangesAsync();
                #endregion

                #region 05. Retornar resposta
                return new Response<Company?>(company, 204, "Empresa excluída com sucesso");
                #endregion

            }
            catch
            {
                return new Response<Company?>(null, 500, "Não foi possível excluir a empresa");
            }
        }
        public async Task<PagedResponse<List<Company>?>> GetAllAsync(GetAllCompaniesRequest request)
        {
            try
            {
                var query = context
                .Companies
                .Include(a => a.Address)
                .Include(a => a.Contacts)
                .AsNoTracking();

                var companies = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return companies.Count == 0
                        ? new PagedResponse<List<Company>?>(null, 404, "Não foram encontradas empresas cadastradas.")
                        : new PagedResponse<List<Company>?>(companies, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Company>?>(null, 500, "Não possível consultar agências.");
            }
        }
        public async Task<Response<Company?>> GetByIdAsync(GetCompanyByIdRequest request)
        {
            try
            {
                var company = await context.Companies
                 .Include(a => a.Address)
                 .Include(a => a.Contacts)
                 .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (company is null)
                    return new Response<Company?>(null, 404, "Empresa não encontrada");

                return new Response<Company?>(company, 200);
            }
            catch
            {
                return new Response<Company?>(null, 500, "Não foi possível consultar a empresa");
            }
        }
        public async Task<Response<Company?>> UpdateAsync(UpdateCompanyRequest request)
        {
            try
            {
                #region 01. Buscar empresa
                var company = await context.Companies
                   .Include(a => a.Address)
                   .Include(a => a.Contacts)
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (company is null)
                    return new Response<Company?>(null, 404, "Empresa não encontrada");

                #endregion

                #region 02. Validar requisição
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<Company?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

                #endregion

                #region 03. Remover Contatos
                if(company.Contacts is not null)
                    context.Contacts.RemoveRange(company.Contacts);

                #endregion

                #region 04. Mapear dados e atualizar dados
                mapper.Map(request, company);

                #endregion

                #region 05. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 06. Retornar Resposta
                return new Response<Company?>(company, 200, "Empresa atualizada com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Company?>(null, 500, "Não foi possível alterar a empresa");
            }
        }
    }
}
