using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;
using AutoMapper;

namespace AgencyManager.Api.Handler
{
    public class EmployeeHandler(AppDbContext context, IMapper mapper) : IEmployeeHandler
    {
        public async Task<Response<Employee>> CreateAsync(CreateEmployeeRequest request)
        {
            try
            {
                request.Validate();
                if(!request.IsValid) return new Response<Employee>(null, 400, "Colaborador inválido");

                var employee = mapper.Map<Employee>(request);
                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();

                return new Response<Employee>(employee, 201, "Colaborador cadastrado com sucesso.");

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
