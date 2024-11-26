using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Sale;
using AgencyManager.Core.Requests.Transaction;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Transactions
{
    public class CreateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapPost("/", HandleAsync)
           .WithName("Transactions: Create")
           .WithSummary("Cadastra uma nova transação")
           .WithDescription("Cadastra uma nova transação")
           .Produces<Response<Transaction?>>();

        private static async Task<IResult> HandleAsync(
            CreateTransactionRequest request,
            ITransactionHandler handler)
        {
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
