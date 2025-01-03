using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IContactHandler
    {
        Task<Response<Contact>> CreateAsync(CreateContactRequest request);
        Task<Response<Contact>> DeleteAsync(DeleteContactRequest request);
        Task<Response<Contact>> GetByIdAsync(GetContactByIdRequest request);
        Task<PagedResponse<List<Contact>?>> GetAllByAgencyAsync(GetContactsByAgencyId request);
        Task<PagedResponse<List<Contact>?>> GetAllByCompanyAsync(GetContactsByCompanyId request);
        Task<PagedResponse<List<Contact>?>> GetAllByEmployeeAsync(GetContactsByEmployeeId request);
        Task<Response<Contact>> UpdateAsync(UpdateContactRequest request);
    }
}