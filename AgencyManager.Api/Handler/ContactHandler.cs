using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Handler
{
    public class ContactHandler(AppDbContext context) : IContactHandler
    {
        public async Task<Response<Contact>> CreateAsync(IList<CreateContactRequest> request)
        {
            try
            {                          
                await context.AddRangeAsync(request);  
                context.SaveChanges();

                return new Response<Contact>(null,200, "Contato(s) criado (s) com sucesso!");
            }
            catch 
            {
                return new Response<Contact>(null, 500, "Não foi possível criar o contato.");
            }
        }

        public Task<Response<Contact>> DeleteAsync(DeleteContactRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Contact>?>> GetByAgencyId(GetContactsByAgencyId request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Contact>?>> GetByCompanyId(GetContactsByCompanyId request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Contact>?>> GetByEmployeeId(GetContactsByEmployeeId request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Contact>> UpdateAsync(UpdateContactRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
