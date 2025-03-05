using AgencyManager.Core.Models.Entities.ValueObjects;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;
using AgencyManager.Core.Services;
using AutoMapper;
using Newtonsoft.Json;

namespace AgencyManager.Web.Services
{
    public class CepService(IHttpClientFactory httpClientFactory) : ICepService
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient("viacep");
        public async Task<Response<Address?>> GetAddressByCepAsync(string cep)
        {
            var response = await _client.GetAsync($"{cep}/json/");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ViaCepDto>(jsonResponse);

            if(result is null) return new Response<Address?>(null, 400, "CEP não encontrado.");

            var address = new Address(result.Cep, result.Logradouro, string.Empty, result.Bairro, result.Localidade, result.Uf, result.Complemento);

            return new Response<Address?>(address,200) 
                ?? new Response<Address?>(null, 400, "CEP não encontrado.");
        }
    }
}
