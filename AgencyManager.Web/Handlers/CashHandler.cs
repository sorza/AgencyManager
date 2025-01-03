using AgencyManager.Core.Common.Extensions;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class CashHandler(IHttpClientFactory httpClientFactory) : ICashHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Cash?>> CreateAsync(CreateCashRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/cashs", request);
            return await result.Content.ReadFromJsonAsync<Response<Cash?>>()
                ?? new Response<Cash?>(null, 400, "Falha ao criar caixa");
        }

        public async Task<Response<Cash?>> DeleteAsync(DeleteCashRequest request)
        {
           var result = await _client.DeleteAsync($"v1/cashs/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Cash?>>()
                ?? new Response<Cash?>(null, 400, "Falha ao deletar caixa");
        }

        public async Task<PagedResponse<List<Cash>?>> GetByAgencyByPeriodAsync(GetCashsByAgencyByPeriodRequest request)
        {
            const string format = "yyyy-MM-dd";
            var startDate = request.StartDate is not null
                ? request.StartDate.Value.ToString(format)
                : DateTime.Now.GetFirstDay().ToString(format);

            var endDate = request.EndDate is not null
                ? request.EndDate.Value.ToString(format)
                : DateTime.Now.GetLastDay().ToString(format);

            var url = $"v1/cashs/agencyByPeriod/{request.AgencyId}?startDate={startDate}&endDate={endDate}";

            return await _client.GetFromJsonAsync<PagedResponse<List<Cash>?>>(url)
                ?? new PagedResponse<List<Cash>?>(null, 400, "Falha ao buscar caixas");
        }

        public async Task<Response<Cash?>> GetByIdAsync(GetCashByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Cash?>>($"v1/cashs/{request.Id}")
            ?? new Response<Cash?>(null, 400, "Falha ao buscar caixa");

        public async Task<PagedResponse<List<Cash>?>> GetByUserByPeriodAsync(GetCashsByUserByPeriodRequest request)
        {
            const string format = "yyyy-MM-dd";
            var startDate = request.StartDate is not null
                ? request.StartDate.Value.ToString(format)
                : DateTime.Now.GetFirstDay().ToString(format);

            var endDate = request.EndDate is not null
                ? request.EndDate.Value.ToString(format)
                : DateTime.Now.GetLastDay().ToString(format);

            var url = $"v1/cashs/userByPeriod/{request.Id}?startDate={startDate}&endDate={endDate}";

            return await _client.GetFromJsonAsync<PagedResponse<List<Cash>?>>(url)
                ?? new PagedResponse<List<Cash>?>(null, 400, "Falha ao buscar caixas");
        }

        public async Task<Response<Cash?>> UpdateAsync(UpdateCashRequest request)
        {
           var result = await _client.PutAsJsonAsync("v1/cashs", request);
            return await result.Content.ReadFromJsonAsync<Response<Cash?>>()
                ?? new Response<Cash?>(null, 400, "Falha ao atualizar caixa");
        }
    }
}
