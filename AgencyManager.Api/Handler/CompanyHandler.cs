using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class CompanyHandler(AppDbContext context, IMapper mapper) : ICompanyHandler
    {
        public async Task<Response<CompanyDto?>> CreateAsync(CreateCompanyRequest request)
        {
            #region 01. Validar requisição

            var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            string errors = string.Empty;

            if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                return new Response<CompanyDto?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

            #endregion

            #region 02. Mapear propriedades e criar empresa
            try
            {
                var company = mapper.Map<Company>(request);

                await context.Companies.AddAsync(company);
                await context.SaveChangesAsync();

                var companyDto = mapper.Map<CompanyDto>(company);
                return new Response<CompanyDto?>(companyDto, 201, "Empresa cadastrada com sucesso.");
            }
            catch
            {
                return new Response<CompanyDto?>(null, 500, "Não foi possível cadastrar empresa");
            }
            #endregion
        }
        public async Task<Response<CompanyDto?>> DeleteAsync(DeleteCompanyRequest request)
        {
            try
            {
                #region 01. Buscar empresa
                var company = await context.Companies
                  .Include(a => a.Address)
                  .Include(a => a.Contacts)
                  .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (company is null)
                    return new Response<CompanyDto?>(null, 404, "Empresa não encontrada");

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
                var companyDto = mapper.Map<CompanyDto>(company);
                return new Response<CompanyDto?>(companyDto, 204, "Empresa excluída com sucesso");
                #endregion

            }
            catch
            {
                return new Response<CompanyDto?>(null, 500, "Não foi possível excluir a empresa");
            }
        }
        public async Task<PagedResponse<List<CompanyDto>?>> GetAllAsync(GetAllCompaniesRequest request)
        {
            try
            {
                var query = context
                .Companies
                .Include(a => a.Address)
                .AsNoTracking();

                var companies = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                var companiesDto = mapper.Map<List<CompanyDto>>(companies);

                return companies.Count == 0
                        ? new PagedResponse<List<CompanyDto>?>(null, 404, "Não foram encontradas empresas cadastradas.")
                        : new PagedResponse<List<CompanyDto>?>(companiesDto, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<CompanyDto>?>(null, 500, "Não possível consultar agências.");
            }
        }
        public async Task<Response<CompanyDto?>> GetByIdAsync(GetCompanyByIdRequest request)
        {
            try
            {
                var company = await context.Companies
                 .Include(a => a.Address)
                 .Include(a => a.Contacts)
                 .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (company is null)
                    return new Response<CompanyDto?>(null, 404, "Empresa não encontrada");

                var companyDto = mapper.Map<CompanyDto>(company);
                return new Response<CompanyDto?>(companyDto, 200);
            }
            catch
            {
                return new Response<CompanyDto?>(null, 500, "Não foi possível consultar a empresa");
            }
        }
        public async Task<Response<CompanyDto?>> UpdateAsync(UpdateCompanyRequest request)
        {
            try
            {
                #region 01. Buscar empresa
                var company = await context.Companies
                   .Include(a => a.Address)
                   .Include(a => a.Contacts)
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (company is null)
                    return new Response<CompanyDto?>(null, 404, "Empresa não encontrada");

                #endregion

                #region 02. Validar requisição
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<CompanyDto?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

                #endregion               

                #region 03. Atualizar lita de contatos
                if (company.Contacts is not null && request.Contacts is not null)
                {
                    var novaListaContatos = mapper.Map<List<Contact>>(request.Contacts);
                    var contatosAExcluir = new List<Contact>();

                    foreach (var contact in company.Contacts)
                        if (!novaListaContatos.Contains(contact))
                            contatosAExcluir.Add(contact);

                    foreach (var contact in contatosAExcluir)
                        context.Contacts.Remove(contact);
                }

                #endregion

                #region 04. Mapear dados e atualizar dados
                mapper.Map(request, company);

                #endregion

                #region 05. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 06. Retornar Resposta
                var companyDto = mapper.Map<CompanyDto>(company);
                return new Response<CompanyDto?>(companyDto, 200, "Empresa atualizada com sucesso");

                #endregion
            }
            catch
            {
                return new Response<CompanyDto?>(null, 500, "Não foi possível alterar a empresa");
            }
        }
    }
}
