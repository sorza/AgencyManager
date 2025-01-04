using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.VirtualSale;
using AgencyManager.Core.Responses;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class VirtualSaleHandler(IHttpClientFactory httpClientFactory) : IVirtualSaleHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<VirtualSale?>> CreateAsync(CreateVirtualSaleRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/virtual-sales", request);
            return await result.Content.ReadFromJsonAsync<Response<VirtualSale?>>()
                ?? new Response<VirtualSale?>(null, 400, "Falha ao criar venda virtual.");
        }

        public async Task<Response<VirtualSale?>> DeleteAsync(DeleteVirtualSaleRequest request)
        {
            var result = await _client.DeleteAsync($"v1/virtual-sales/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<VirtualSale?>>()
                ?? new Response<VirtualSale?>(null, 400, "Falha ao deletar venda virtual.");
        }

        public async Task<PagedResponse<List<VirtualSale>?>> GetAllByCashIdAsync(GetVirtualSalesByCashIdRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<VirtualSale>?>>($"v1/virtual-sales/cash/{request.CashId}")
            ?? new PagedResponse<List<VirtualSale>?>(null, 400, "Falha ao buscar vendas virtuais.");

        public async Task<Response<VirtualSale?>> GetByIdAsync(GetVirtualSalesByIdRequest request)
        => await _client.GetFromJsonAsync<Response<VirtualSale?>>($"v1/virtual-sales/{request.Id}")
            ?? new Response<VirtualSale?>(null, 400, "Falha ao buscar venda virtual.");

        public async Task<Response<VirtualSale?>> UpdateAsync(UpdateVirtualSaleRequest request)
        {
            var result = await _client.PutAsJsonAsync("v1/virtual-sales", request);
            return await result.Content.ReadFromJsonAsync<Response<VirtualSale?>>()
                ?? new Response<VirtualSale?>(null, 400, "Falha ao atualizar venda virtual.");
        }
    }
}
