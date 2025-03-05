using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class CompanyHandler(IHttpClientFactory httpClientFactory) : ICompanyHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<CompanyDto?>> CreateAsync(CreateCompanyRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/companies", request);
            return await result.Content.ReadFromJsonAsync<Response<CompanyDto?>>()
                ?? new Response<CompanyDto?>(null, 400, "Falha ao criar empresa");
        }

        public async Task<Response<CompanyDto?>> DeleteAsync(DeleteCompanyRequest request)
        {
            var result = await _client.DeleteAsync($"v1/companies/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<CompanyDto?>>()
                ?? new Response<CompanyDto?>(null, 400, "Falha ao excluir empresa");
        }

        public async Task<PagedResponse<List<CompanyDto>?>> GetAllAsync(GetAllCompaniesRequest request)
        {
            var result = await _client.GetFromJsonAsync<PagedResponse<List<CompanyDto>?>>("v1/companies")
                  ?? new PagedResponse<List<CompanyDto>?>(null, 400, "Falha ao retornar empresas");

            return result;
        }
        

        public async Task<Response<CompanyDto?>> GetByIdAsync(GetCompanyByIdRequest request)
        => await _client.GetFromJsonAsync<Response<CompanyDto?>>($"v1/companies/{request.Id}")
            ?? new Response<CompanyDto?>(null, 400, "Falha ao retornar a empresa");

        public async Task<Response<CompanyDto?>> UpdateAsync(UpdateCompanyRequest request)
        {
           var result = await _client.PutAsJsonAsync($"v1/companies/{request.Id}", request);
           return await result.Content.ReadFromJsonAsync<Response<CompanyDto?>>()
                  ?? new Response<CompanyDto?>(null, 400, "Falha ao atualizar empresa");
        }
    }
}
