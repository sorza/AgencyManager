using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface ICompanyHandler
    {
        Task<Response<Company>> CreateAsync(CreateCompanyRequest request);
        Task<Response<Company>> DeleteAsync(DeleteCompanyRequest request);
        Task<Response<Company>> UpdateAsync(UpdateCompanyRequest request);
        Task<PagedResponse<List<Company>?>> GetAllAsync(GetAllCompaniesRequest request);
    }
}