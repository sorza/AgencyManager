using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Sale;
using AgencyManager.Core.Responses;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class SaleHandler(IHttpClientFactory httpClientFactory) : ISaleHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Sale?>> CreateAsync(CreateSaleRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/sales", request);
            return await result.Content.ReadFromJsonAsync<Response<Sale?>>()
                ?? new Response<Sale?>(null, 400, "Falha ao criar venda");
        }

        public async Task<Response<Sale?>> DeleteAsync(DeleteSaleRequest request)
        {
            var result = await _client.DeleteAsync($"v1/sales/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Sale?>>()
                ?? new Response<Sale?>(null, 400, "Falha ao deletar venda");
        }

        public async Task<PagedResponse<List<Sale>?>> GetAllByCashAsync(GetSalesByCashRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Sale>?>>($"v1/sales/cash/{request.CashId}")
            ?? new PagedResponse<List<Sale>?>(null, 400, "Falha ao buscar vendas do caixa");

        public async Task<Response<Sale?>> GetByIdAsync(GetSaleByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Sale?>>($"v1/sales/{request.Id}")
            ?? new Response<Sale?>(null, 400, "Falha ao buscar venda");

        public async Task<Response<Sale?>> UpdateAsync(UpdateSaleRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/sales/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Sale?>>()
                ?? new Response<Sale?>(null, 400, "Falha ao atualizar venda");
        }
    }
}
