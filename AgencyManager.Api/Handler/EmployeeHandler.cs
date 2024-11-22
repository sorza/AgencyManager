using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class EmployeeHandler(AppDbContext context, IMapper mapper) : IEmployeeHandler
    {
        public async Task<Response<Employee>> CreateAsync(CreateEmployeeRequest request)
        {
            try
            {
                #region 01. Validar Colaborador
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<Employee>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

                #endregion

                #region 02. Mapear dados da requisição para classe concreta
                var employee = mapper.Map<Employee>(request);

                #endregion

                #region 03. Cadastrar colaborador
                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<Employee>(employee, 201, "Colaborador cadastrado com sucesso.");

                #endregion

            }
            catch 
            {
                return new Response<Employee>(null, 500, "Não foi possível cadastrar o colaborador");
            }
        }
        public async Task<Response<Employee>> DeleteAsync(DeleteEmployeeRequest request)
        {
            try
            {
                #region 01. Buscar colaborador
                var employee = await context
                .Employees
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (employee is null) return new Response<Employee>(null, 404, "Colaborador não encontrado");

                #endregion

                #region 02. Remover colaborador
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();

                #endregion

                #region 03. Retornar resposta
                return new Response<Employee>(employee, 200, "Colaborador excluído com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Employee>(null, 500, "Não foi possível excluir o colaborador");
            }
        }
        public async Task<PagedResponse<List<Employee>?>> GetAllByAgencyIdAsync(GetAllEmployeesByAgencyIdRequest request)
        {
            try
            {
                #region 01. Buscar colaboradores por agencia
                var query = context
                .Employees
                .AsNoTracking()
                .Include(a => a.Address)
                .Include(a => a.Contacts)
                .Where(x => x.AgencyId == request.AgencyId);

                #endregion

                #region 02. Paginar de acordo com o especificado
                var employees = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                #endregion

                #region 03. Obter quantidade de colaboradores
                var count = await query.CountAsync();

                #endregion

                #region 04. Retornar Resposta
                return employees is null
                        ? new PagedResponse<List<Employee>?>(null, 404, "Não foram encontrados colaboradores para esta agencia.")
                        : new PagedResponse<List<Employee>?>(employees, count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<Employee>?>(null, 500, "Não possível consultar os colaboradores.");
            }
        }
        public async Task<Response<Employee>> GetByIdAsync(GetEmployeeByIdRequest request)
        {
            try
            {
                var employee = await context
                .Employees
                .AsNoTracking()
                .Include(a => a.Address)
                .Include(a => a.Contacts)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (employee is null) return new Response<Employee>(null, 404, "Colaborador não encontrado");

                return new Response<Employee>(employee, 200);
            }
            catch
            {
                return new Response<Employee>(null, 500, "Não foi possível buscar colaborador");
            }            
        }
        public async Task<Response<Employee>> UpdateAsync(UpdateEmployeeRequest request)
        {
            try
            {
                #region 01. Buscar colaborador
                var employee = await context
                .Employees
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (employee is null) return new Response<Employee>(null, 404, "Colaborador não encontrado");

                #endregion

                #region 02. Validar Colaborador
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<Employee>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

                #endregion

                #region 03. Atualizar dados
                mapper.Map(request, employee);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<Employee>(employee, 200, "Colaborador atualizado com sucesso!");
                
                #endregion

            }
            catch
            {
                return new Response<Employee>(null, 500, "Não foi possível atualizar o colaborador");
            }
            
        }
    }
}
