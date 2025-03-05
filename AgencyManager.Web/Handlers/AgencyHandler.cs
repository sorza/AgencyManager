using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class AgencyHandler(IHttpClientFactory httpClientFactory) : IAgencyHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<AgencyDto?>> CreateAsync(CreateAgencyRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/agencies", request);
            return await result.Content.ReadFromJsonAsync<Response<AgencyDto?>>()
                ?? new Response<AgencyDto?>(null, 400, "Falha ao criar agência");
        }

        public async Task<Response<AgencyDto?>> DeleteAsync(DeleteAgencyRequest request)
        {
            var result = await _client.DeleteAsync($"v1/agencies/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<AgencyDto?>>()
                ?? new Response<AgencyDto?>(null, 400, "Falha ao excluir agência");
        }

        public async Task<PagedResponse<List<AgencyDto>?>> GetAllAsync(GetAllAgenciesRequest request)
         => await _client.GetFromJsonAsync<PagedResponse<List<AgencyDto>?>>("v1/agencies")
             ?? new PagedResponse<List<AgencyDto>?>(null, 400, "Falha ao retornar agências");

        public async Task<Response<AgencyDto?>> GetByIdAsync(GetAgencyByIdRequest request)
         => await _client.GetFromJsonAsync<Response<AgencyDto?>>($"v1/agencies/{request.Id}")
             ?? new Response<AgencyDto?>(null, 400, "Falha ao retornar a agência");

        public async Task<Response<AgencyDto?>> UpdateAsync(UpdateAgencyRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/agencies/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<AgencyDto?>>()
                ?? new Response<AgencyDto?>(null, 400, "Falha ao atualizar agência");
        }
    }
}
