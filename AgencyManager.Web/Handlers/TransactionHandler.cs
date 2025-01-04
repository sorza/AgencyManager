using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Transaction;
using AgencyManager.Core.Responses;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class TransactionHandler(IHttpClientFactory httpClientFactory) : ITransactionHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/transactions", request);
            return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
                ?? new Response<Transaction?>(null,400, "Falha ao criar transação.");
        }

        public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
        {
           var result = await _client.DeleteAsync($"v1/transactions/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
                ?? new Response<Transaction?>(null, 400, "Falha ao deletar transação.");
        }

        public async Task<PagedResponse<List<Transaction>?>> GetAllByCashAsync(GetTransactionsByCashIdRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Transaction>?>>($"v1/transactions/cash/{request.CashId}")
            ?? new PagedResponse<List<Transaction>?>(null,400,"Falha ao buscar transações.");

        public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Transaction?>>($"v1/transactions/{request.Id}")
            ?? new Response<Transaction?>(null, 400, "Falha ao buscar transação.");

        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
        {
            var result = await _client.PutAsJsonAsync("v1/transactions", request);
            return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
                ?? new Response<Transaction?>(null, 400, "Falha ao atualizar transação.");
        }
    }
}
