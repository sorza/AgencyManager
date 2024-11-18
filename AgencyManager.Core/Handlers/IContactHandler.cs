using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IContactHandler
    {
        Task<Response<Contact>> CreateAsync(IList<CreateContactRequest> request);
        Task<Response<Contact>> DeleteAsync(DeleteContactRequest request);
        Task<PagedResponse<List<Contact>?>> GetByAgencyId(GetContactsByAgencyId request);
        Task<PagedResponse<List<Contact>?>> GetByCompanyId(GetContactsByCompanyId request);
        Task<PagedResponse<List<Contact>?>> GetByEmployeeId(GetContactsByEmployeeId request);
        Task<Response<Contact>> UpdateAsync(UpdateContactRequest request);
    }
}