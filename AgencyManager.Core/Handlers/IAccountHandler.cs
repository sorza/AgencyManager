using AgencyManager.Core.Requests.Account;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface IAccountHandler
    {
        Task<Response<string>> LoginAsync(LoginRequest request);
        Task LogoutAsync();
    }
}