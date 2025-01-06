using AgencyManager.Core.DTOs;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface ICompanyHandler
    {
        Task<Response<CompanyDto?>> CreateAsync(CreateCompanyRequest request);
        Task<Response<CompanyDto?>> DeleteAsync(DeleteCompanyRequest request);
        Task<Response<CompanyDto?>> UpdateAsync(UpdateCompanyRequest request);
        Task<Response<CompanyDto?>> GetByIdAsync(GetCompanyByIdRequest request);
        Task<PagedResponse<List<CompanyDto>?>> GetAllAsync(GetAllCompaniesRequest request);
    }
}