using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Locality;
using AgencyManager.Core.Responses;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class LocalityHandler(IHttpClientFactory httpClientFactory) : ILocalityHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Locality?>> CreateAsync(CreateLocalityRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/localities", request);
            return await result.Content.ReadFromJsonAsync<Response<Locality?>>()
                ?? new Response<Locality?>(null, 400, "Falha ao criar localidade");
        }

        public async Task<Response<Locality?>> DeleteAsync(DeleteLocalityRequest request)
        {
            var result = await _client.DeleteAsync($"v1/localities/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Locality?>>()
                ?? new Response<Locality?>(null, 400, "Falha ao deletar localidade");
        }

        public async Task<PagedResponse<List<Locality>?>> GetAllAsync(GetAllLocalitiesRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Locality>?>>("v1/localities")
            ?? new PagedResponse<List<Locality>?>(null, 400, "Falha ao buscar localidades");

        public async Task<Response<Locality?>> GetByIdAsync(GetLocalityByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Locality?>>($"v1/localities/{request.Id}")
            ?? new Response<Locality?>(null, 400, "Falha ao buscar localidade");

        public async Task<Response<Locality?>> UpdateAsync(UpdateLocalityRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/localities/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Locality?>>()
                ?? new Response<Locality?>(null, 400, "Falha ao atualizar localidade");
        }
    }
}
