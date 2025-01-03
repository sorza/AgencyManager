using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;

namespace AgencyManager.Web.Handlers
{
    public class ContactHandler : IContactHandler
    {
        public Task<Response<Contact>> CreateAsync(CreateContactRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Contact>> DeleteAsync(DeleteContactRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Contact>?>> GetAllByAgencyAsync(GetContactsByAgencyId request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Contact>?>> GetAllByCompanyAsync(GetContactsByCompanyId request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Contact>?>> GetAllByEmployeeAsync(GetContactsByEmployeeId request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Contact>> UpdateAsync(UpdateContactRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
