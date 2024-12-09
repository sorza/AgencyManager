using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Positions
{
    public class GetPositionByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
           .WithName("Positions: Get By Id")
           .WithSummary("Recupera um cargo")
           .WithDescription("Recupera um cargo")
           .Produces<Response<Position?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
             IPositionHandler handler, int id)
        {
            var request = new GetPositionByIdRequest
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
