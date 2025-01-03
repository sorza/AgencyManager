using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class CompanyHandler(IHttpClientFactory httpClientFactory) : ICompanyHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Company?>> CreateAsync(CreateCompanyRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/companies", request);
            return await result.Content.ReadFromJsonAsync<Response<Company?>>()
                ?? new Response<Company?>(null, 400, "Falha ao criar empresa");
        }

        public async Task<Response<Company?>> DeleteAsync(DeleteCompanyRequest request)
        {
            var result = await _client.DeleteAsync($"v1/companies/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Company?>>()
                ?? new Response<Company?>(null, 400, "Falha ao excluir empresa");
        }

        public async Task<PagedResponse<List<Company>?>> GetAllAsync(GetAllCompaniesRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Company>?>>("v1/companies")
            ?? new PagedResponse<List<Company>?>(null, 400, "Falha ao retornar empresas");

        public async Task<Response<Company?>> GetByIdAsync(GetCompanyByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Company?>>($"v1/companies/{request.Id}")
            ?? new Response<Company?>(null, 400, "Falha ao retornar a empresa");

        public async Task<Response<Company?>> UpdateAsync(UpdateCompanyRequest request)
        {
           var result = await _client.PutAsJsonAsync($"v1/companies/{request.Id}", request);
           return await result.Content.ReadFromJsonAsync<Response<Company?>>()
                  ?? new Response<Company?>(null, 400, "Falha ao atualizar empresa");
        }
    }
}
