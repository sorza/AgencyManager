using AgencyManager.Core.DTOs;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IEmployeeHandler
    {
        Task<Response<EmployeeDto?>> CreateAsync(CreateEmployeeRequest request);
        Task<Response<EmployeeDto?>> DeleteAsync(DeleteEmployeeRequest request);        
        Task<PagedResponse<List<EmployeeDto>?>> GetAllByAgencyIdAsync(GetAllEmployeesByAgencyIdRequest request);
        Task<Response<EmployeeDto?>> GetByIdAsync(GetEmployeeByIdRequest request);
        Task<Response<EmployeeDto?>> UpdateAsync(UpdateEmployeeRequest request);

    }
}