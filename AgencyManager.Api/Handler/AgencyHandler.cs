using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.Entities.ValueObjects;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;
using AutoMapper;

namespace AgencyManager.Api.Handler
{
    public class AgencyHandler(AppDbContext context, IMapper mapper) : IAgencyHandler
    {
        public async Task<Response<Agency>> CreateAsync(CreateAgencyRequest request)
        {
            request.Validate();

            if (request.IsValid)
            {       
                try
                {
                    var address = mapper.Map<Address>(request.Address);
                    var contacts = new List<Contact>();

                    foreach (var contact in request.Contacts)                    
                        contacts.Add(mapper.Map<Contact>(contact));                    

                    var agency = new Agency(request.Description, request.Cnpj, address, contacts, request.Photo);

                    await context.Agencies.AddAsync(agency);
                    await context.SaveChangesAsync();

                    return new Response<Agency>(agency);
                }
                catch
                {
                    return new Response<Agency>(null, 500, "Não foi possível criar agência");
                }
            }
            else
            {                 
                return new Response<Agency>(null, 400, string.Join(", ", request.Notifications.Select(n => n.Message)));               
            }            
        }            
        
        public Task<Response<Agency>> DeleteAsync(DeleteAgencyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Agency>?>> GetAllAsync(GetAllAgenciesRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Agency>> GetByIdAsync(GetAgencyByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Agency>> UpdateAsync(UpdateAgencyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
