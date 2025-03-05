using AgencyManager.Core.Common.Extensions;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class CashHandler(IHttpClientFactory httpClientFactory) : ICashHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<CashDto?>> CreateAsync(CreateCashRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/cashs", request);
            return await result.Content.ReadFromJsonAsync<Response<CashDto?>>()
                ?? new Response<CashDto?>(null, 400, "Falha ao criar caixa");
        }

        public async Task<Response<CashDto?>> DeleteAsync(DeleteCashRequest request)
        {
           var result = await _client.DeleteAsync($"v1/cashs/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<CashDto?>>()
                ?? new Response<CashDto?>(null, 400, "Falha ao deletar caixa");
        }

        public async Task<PagedResponse<List<CashDto>?>> GetByAgencyByPeriodAsync(GetCashsByAgencyByPeriodRequest request)
        {
            const string format = "yyyy-MM-dd";
            var startDate = request.StartDate is not null
                ? request.StartDate.Value.ToString(format)
                : DateTime.Now.GetFirstDay().ToString(format);

            var endDate = request.EndDate is not null
                ? request.EndDate.Value.ToString(format)
                : DateTime.Now.GetLastDay().ToString(format);

            var url = $"v1/cashs/agencyByPeriod/{request.AgencyId}?startDate={startDate}&endDate={endDate}";

            return await _client.GetFromJsonAsync<PagedResponse<List<CashDto>?>>(url)
                ?? new PagedResponse<List<CashDto>?>(null, 400, "Falha ao buscar caixas");
        }

        public async Task<Response<CashDto?>> GetByIdAsync(GetCashByIdRequest request)
        => await _client.GetFromJsonAsync<Response<CashDto?>>($"v1/cashs/{request.Id}")
            ?? new Response<CashDto?>(null, 400, "Falha ao buscar caixa");

        public async Task<PagedResponse<List<CashDto>?>> GetByUserByPeriodAsync(GetCashsByUserByPeriodRequest request)
        {
            const string format = "yyyy-MM-dd";
            var startDate = request.StartDate is not null
                ? request.StartDate.Value.ToString(format)
                : DateTime.Now.GetFirstDay().ToString(format);

            var endDate = request.EndDate is not null
                ? request.EndDate.Value.ToString(format)
                : DateTime.Now.GetLastDay().ToString(format);

            var url = $"v1/cashs/userByPeriod/{request.UserId}?startDate={startDate}&endDate={endDate}";

            return await _client.GetFromJsonAsync<PagedResponse<List<CashDto>?>>(url)
                ?? new PagedResponse<List<CashDto>?>(null, 400, "Falha ao buscar caixas");
        }

        public async Task<Response<CashDto?>> UpdateAsync(UpdateCashRequest request)
        {
           var result = await _client.PutAsJsonAsync("v1/cashs", request);
            return await result.Content.ReadFromJsonAsync<Response<CashDto?>>()
                ?? new Response<CashDto?>(null, 400, "Falha ao atualizar caixa");
        }
    }
}
