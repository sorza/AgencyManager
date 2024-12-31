using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Account;
using AgencyManager.Core.Responses;
using AgencyManager.Web;
using System.Net.Http.Json;
using System.Text;

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
                : new Response<string>(null, 400, "Não foi possível realizar login.");
        }

        public async Task LogoutAsync()
        {
            var empityContext = new StringContent("{}", Encoding.UTF8, "application/json");
            await _client.PostAsJsonAsync("v1/identity/logout", empityContext);
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/identity/register", request);
            return result.IsSuccessStatusCode
                ? new Response<string>("Cadastro realizado com sucesso!", 201, "Cadastro realizado com sucesso!")
                : new Response<string>(null, 400, "Não foi possível realizar seu cadastro.");
        }
    }
}
