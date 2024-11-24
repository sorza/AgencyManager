using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Cashs
{
    public class DeleteCashEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapDelete("/{id}", HandleAsync)
            .WithName("Cashs: Delete")
            .WithSummary("Excui um caixa")
            .WithDescription("Exclui um caixa")
            .Produces<Response<Cash?>>();

        private static async Task<IResult> HandleAsync(
             ICashHandler handler, int id)
        {
            var request = new DeleteCashRequest
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
