using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Cashs
{
    public class UpdateCashEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
           .WithName("Cashs: Update")
           .WithSummary("Atualiza um caixa")
           .WithDescription("Atualiza um caixa")
           .Produces<Response<Cash?>>();

        private static async Task<IResult> HandleAsync(
            ICashHandler handler,
            UpdateCashRequest request,
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
