using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Transaction;
using AgencyManager.Core.Responses;
using System.Transactions;

namespace AgencyManager.Api.Handler
{
    public class TransactionHandler : ITransactionHandler
    {
        public Task<Response<Transaction>> CreateAsync(CreateTransactionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Transaction>> DeleteAsync(DeleteTransactionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Transaction>?>> GetAllByCashAsync(GetTransactionsByCashId request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Transaction>> GetByIdAsync(GetTransactionByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Transaction>> UpdateAsync(UpdateTransactionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
