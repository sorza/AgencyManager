using AgencyManager.Core.Models.Entities.ValueObjects;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Services
{
    public interface ICepService
    {
        Task<Response<Address?>> GetAddressByCepAsync(string cep);
    }
}
