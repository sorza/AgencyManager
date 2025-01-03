using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class ContractHandler(IHttpClientFactory httpClientFactory) : IContractHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<ContractService?>> CreateAsync(CreateContractServiceRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/contracts", request);
            return await result.Content.ReadFromJsonAsync<Response<ContractService?>>()
                ?? new Response<ContractService?>(null, 400, "Falha ao criar contrato");
        }

        public async Task<Response<ContractService?>> DeleteAsync(DeleteContractServiceRequest request)
        {
            var result = await _client.DeleteAsync($"v1/contracts/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<ContractService?>>()
                ?? new Response<ContractService?>(null, 400, "Falha ao excluir contrato");
        }

        public async Task<PagedResponse<List<ContractService>?>> GetByAgencyIdAsync(GetAllContractsByAgencyRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<ContractService>?>>("v1/contracts")
            ?? new PagedResponse<List<ContractService>?>(null, 400, "Falha ao retornar contratos da agência");

        public async Task<Response<ContractService?>> GetByIdAsync(GetContractByIdRequest request)
        => await _client.GetFromJsonAsync<Response<ContractService?>>($"v1/contracts/{request.Id}")
            ?? new Response<ContractService?>(null, 400, "Falha ao retornar o contrato");

        public async Task<Response<ContractService?>> UpdateAsync(UpdateContractServiceRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/contracts/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<ContractService?>>()
                   ?? new Response<ContractService?>(null, 400, "Falha ao atualizar contrato");
        }
    }
}
