using System.Transactions;
using AgencyManager.Core.Requests.Transaction;
using AgencyManager.Core.Responses;

namespace AgencyManager.Core.Handlers
{
    public interface ITransactionHandler
    {
        Task<Response<Transaction>> CreateAsync (CreateTransactionRequest request);
        Task<Response<Transaction>> UpdateAsync (UpdateTransactionRequest request);
        Task<Response<Transaction>> DeleteAsync (DeleteTransactionRequest request);
        Task<PagedResponse<List<Transaction>?>> GetAllByCashAsync (GetTransactionsByCashId request);
    }
}