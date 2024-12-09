using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Models;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Cashs
{
    public class GetCashByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapGet("/{id}", HandleAsync)
            .WithName("Cashs: Get Cash By Id")
            .WithSummary("Recupera um caixa por id")
            .WithDescription("Recupera um caixa por id")
            .Produces<Response<Cash?>>();

        private static async Task<IResult> HandleAsync(
             ClaimsPrincipal user, ICashHandler handler, int id)
        {
            var request = new GetCashByIdRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
