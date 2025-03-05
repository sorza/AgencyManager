using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class ContactHandler(IHttpClientFactory httpClientFactory) : IContactHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<ContactDto?>> CreateAsync(CreateContactRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/contacts", request);
            return await result.Content.ReadFromJsonAsync<Response<ContactDto?>>()
                ?? new Response<ContactDto?>(null, 400, "Falha ao criar contato");
        }

        public async Task<Response<ContactDto?>> DeleteAsync(DeleteContactRequest request)
        {
            var result = await _client.DeleteAsync($"v1/contacts/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<ContactDto?>>()
                ?? new Response<ContactDto?>(null, 400, "Falha ao excluir contato");
        }

        public async Task<PagedResponse<List<ContactDto>?>> GetAllByAgencyAsync(GetContactsByAgencyId request)
            => await _client.GetFromJsonAsync<PagedResponse<List<ContactDto>?>>($"v1/contacts/agency/{request.AgencyId}")
                ?? new PagedResponse<List<ContactDto>?>(null, 400, "Falha ao retornar contatos da agência");

        public async Task<PagedResponse<List<ContactDto>?>> GetAllByCompanyAsync(GetContactsByCompanyId request)
            => await _client.GetFromJsonAsync<PagedResponse<List<ContactDto>?>>($"v1/contacts/company/{request.CompanyId}")
                ?? new PagedResponse<List<ContactDto>?>(null, 400, "Falha ao retornar contatos da empresa");

        public async Task<PagedResponse<List<ContactDto>?>> GetAllByEmployeeAsync(GetContactsByEmployeeId request)
            => await _client.GetFromJsonAsync<PagedResponse<List<ContactDto>?>>($"v1/contacts/employee/{request.EmployeeId}")
                ?? new PagedResponse<List<ContactDto>?>(null, 400, "Falha ao retornar contatos do funcionário");

        public async Task<Response<ContactDto?>> GetByIdAsync(GetContactByIdRequest request)
           => await _client.GetFromJsonAsync<Response<ContactDto?>>($"v1/contacts/{request.Id}")
                ?? new Response<ContactDto?>(null, 400, "Falha ao retornar o contato");

        public async Task<Response<ContactDto?>> UpdateAsync(UpdateContactRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/contacts/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<ContactDto?>>()
                ?? new Response<ContactDto?>(null, 400, "Falha ao atualizar contato");
        }
    }
}
