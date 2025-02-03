using AgencyManager.Core.DTOs;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IContactHandler
    {
        Task<Response<ContactDto?>> CreateAsync(CreateContactRequest request);
        Task<Response<ContactDto?>> DeleteAsync(DeleteContactRequest request);
        Task<Response<ContactDto?>> GetByIdAsync(GetContactByIdRequest request);
        Task<PagedResponse<List<ContactDto>?>> GetAllByAgencyAsync(GetContactsByAgencyId request);
        Task<PagedResponse<List<ContactDto>?>> GetAllByCompanyAsync(GetContactsByCompanyId request);
        Task<PagedResponse<List<ContactDto>?>> GetAllByEmployeeAsync(GetContactsByEmployeeId request);
        Task<Response<ContactDto?>> UpdateAsync(UpdateContactRequest request);      
    }
}