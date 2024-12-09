using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Requests.Sale;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Sales
{
    public class GetSaleByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
          .WithName("Sales: Get By Id")
          .WithSummary("Recupera uma venda")
          .WithDescription("Recupera uma venda")
          .Produces<Response<Sale?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
             ISaleHandler handler, int id)
        {
            var request = new GetSaleByIdRequest
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
