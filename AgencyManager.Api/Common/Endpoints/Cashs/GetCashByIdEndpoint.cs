using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Cashs
{
    public class GetCashByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapGet("/{id}", HandleAsync)
            .WithName("Cashs: Get By Id")
            .WithSummary("Recupera um caixa por id")
            .WithDescription("Recupera um caixa por id")
            .Produces<Response<Cash?>>();

        private static async Task<IResult> HandleAsync(
             ICashHandler handler, int id)
        {
            var request = new GetCashByIdRequest
            {
                UserId = "teste@teste.com",
                Id = id
            };

            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
