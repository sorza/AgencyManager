using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Agencies
{
    public class CreateAgencyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Agencies: Create")
            .WithSummary("Cria uma nova agência")
            .WithDescription("Cria uma nova agência")
            .Produces<Response<Agency?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IAgencyHandler handler,
            CreateAgencyRequest request)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
