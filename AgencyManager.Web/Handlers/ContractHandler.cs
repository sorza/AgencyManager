using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class ContractHandler(IHttpClientFactory httpClientFactory) : IContractHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<ContractDto?>> CreateAsync(CreateContractServiceRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/contracts", request);
            return await result.Content.ReadFromJsonAsync<Response<ContractDto?>>()
                ?? new Response<ContractDto?>(null, 400, "Falha ao criar contrato");
        }

        public async Task<Response<ContractDto?>> DeleteAsync(DeleteContractServiceRequest request)
        {
            var result = await _client.DeleteAsync($"v1/contracts/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<ContractDto?>>()
                ?? new Response<ContractDto?>(null, 400, "Falha ao excluir contrato");
        }

        public async Task<PagedResponse<List<ContractDto>?>> GetByAgencyIdAsync(GetAllContractsByAgencyRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<ContractDto>?>>($"v1/contracts/{request.AgencyId}?pageNumber={request.PageNumber}&pageSize={request.PageSize}")
            ?? new PagedResponse<List<ContractDto>?>(null, 400, "Falha ao retornar contratos da agência");

        public async Task<Response<ContractDto?>> GetByIdAsync(GetContractByIdRequest request)
        => await _client.GetFromJsonAsync<Response<ContractDto?>>($"v1/contracts/{request.Id}")
            ?? new Response<ContractDto?>(null, 400, "Falha ao retornar o contrato");

        public async Task<Response<ContractDto?>> UpdateAsync(UpdateContractServiceRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/contracts/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<ContractDto?>>()
                   ?? new Response<ContractDto?>(null, 400, "Falha ao atualizar contrato");
        }
    }
}
