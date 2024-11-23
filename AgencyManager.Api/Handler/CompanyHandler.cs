using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Handler
{
    public class CompanyHandler : ICompanyHandler
    {
        public Task<Response<Company>> CreateAsync(CreateCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Company>> DeleteAsync(DeleteCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Company>?>> GetAllAsync(GetAllCompaniesRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Company>> UpdateAsync(UpdateCompanyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
