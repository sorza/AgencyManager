using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Account;
using AgencyManager.Core.Responses;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class AccountHandler(IHttpClientFactory httpClientFactory) : IAccountHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<string>> LoginAsync(LoginRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/identity/login?useCookies=true", request);
            return result.IsSuccessStatusCode
                ? new Response<string>("Login realizado com sucesso!", 200, "Login realizado com sucesso!")
                : new Response<string>(null, (int)result.StatusCode, "Não foi possível realizar o login.");
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/identity/register", request);
            return result.IsSuccessStatusCode
                ? new Response<string>("Cadastro realizado com sucesso!", 201, "Cadastro realizado com sucesso!")
                : new Response<string>(null, (int)result.StatusCode, "Não foi possível realizar o cadastro.");
        }
    }
}
