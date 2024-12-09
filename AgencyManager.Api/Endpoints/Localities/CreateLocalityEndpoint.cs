using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Locality;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Localities
{
    public class CreateLocalityEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Localities: Create")
            .WithSummary("Cria uma nova localidade")
            .WithDescription("Cria uma nova localidade")
            .Produces<Response<Locality?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ILocalityHandler handler,
            CreateLocalityRequest request)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
