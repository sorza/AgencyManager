using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Requests.Sale;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Sales
{
    public class DeleteSaleEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
            .WithName("Sales: Delete")
            .WithSummary("Exclui uma venda")
            .WithDescription("Exclui uma venda")
            .Produces<Response<Sale?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ISaleHandler handler,
            int id)
        {
            var request = new DeleteSaleRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.DeleteAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
