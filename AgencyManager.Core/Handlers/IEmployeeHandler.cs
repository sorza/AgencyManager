using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IEmployeeHandler
    {
        Task<Response<Employee>> CreateAsync(CreateEmployeeRequest request);
        Task<Response<Employee>> DeleteAsync(DeleteEmployeeRequest request);        
        Task<PagedResponse<List<Employee>?>> GetAllByAgencyIdAsync(GetAllEmployeesByAgencyIdRequest request);
        Task<PagedResponse<List<Employee>?>> GetAllAsync(GetAllEmployeesRequest request);
        Task<Response<Employee>> GetByIdAsync(GetEmployeeByIdRequest request);
        Task<Response<Employee>> UpdateAsync(UpdateEmployeeRequest request);

    }
}