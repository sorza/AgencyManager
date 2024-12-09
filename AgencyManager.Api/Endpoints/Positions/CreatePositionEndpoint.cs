using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Models;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Positions
{
    public class CreatePositionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Position: Create")
            .WithSummary("Cadastra um novo cargo")
            .WithDescription("Cadastra um novo cargo")
            .Produces<Response<Position?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            CreatePositionRequest request,
            IPositionHandler handler)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
