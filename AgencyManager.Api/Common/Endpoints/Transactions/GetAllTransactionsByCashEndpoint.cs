using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Responses;
using AgencyManager.Core;
using Microsoft.AspNetCore.Mvc;
using AgencyManager.Core.Requests.Transaction;

namespace AgencyManager.Api.Common.Endpoints.Transactions
{
    public class GetAllTransactionsByCashEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/cash/{id}", HandleAsync)
               .WithName("Transactions: Get Transactions By Cash")
               .WithSummary("Busca transações de um caixa")
               .WithDescription("Busca transações de um caixa")
               .Produces<PagedResponse<List<Transaction>?>>();

        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler, int id,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetTransactionsByCashIdRequest
            {
                UserId = "teste@teste.com",
                PageNumber = pageNumber,
                PageSize = pageSize,
                CashId = id
            };

            var result = await handler.GetAllByCashAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
