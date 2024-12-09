using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Locality;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Localities
{
    public class GetLocalityByIdEndpoit : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/{id}", HandleAsync)
           .WithName("Localities: Get By Id")
           .WithSummary("Recupera uma localidade")
           .WithDescription("Recupera uma localidade")
           .Produces<Response<Locality?>>();

        private static async Task<IResult> HandleAsync(
             ClaimsPrincipal user, ILocalityHandler handler, int id)
        {
            var request = new GetLocalityByIdRequest
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
