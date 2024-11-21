using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;
using AutoMapper;
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

        public Task<Response<Employee>> DeleteAsync(DeleteEmployeeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Employee>?>> GetAllAsync(GetAllEmployeesRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Employee>?>> GetAllByAgencyIdAsync(GetAllEmployeesByAgencyIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Employee>> GetByIdAsync(GetEmployeeByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Employee>> UpdateAsync(UpdateEmployeeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
