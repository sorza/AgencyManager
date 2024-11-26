using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Transaction;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Transactions
{
    public class DeleteTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
              => app.MapDelete("/{id}", HandleAsync)
              .WithName("Transactions: Delete")
              .WithSummary("Exclui uma transação")
              .WithDescription("Exclui uma transação")
              .Produces<Response<Transaction?>>();

        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            int id)
        {
            var request = new DeleteTransactionRequest
            {
                UserId = "teste@teste.com",
                Id = id
            };

            var result = await handler.DeleteAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
