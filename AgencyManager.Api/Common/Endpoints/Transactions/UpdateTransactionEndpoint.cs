using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Sale;
using AgencyManager.Core.Requests.Transaction;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Transactions
{
    public class UpdateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandleAsync)
                   .WithName("Transactions: Update")
                   .WithSummary("Atualiza uma transação")
                   .WithDescription("Atualiza uma transação")
                   .Produces<Response<Sale?>>();
        }

        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            UpdateTransactionRequest request,
            int id)
        {
            request.UserId = "teste@teste.com";
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
