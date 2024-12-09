using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Agencies
{
    public class UpdateAgencyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapPut("/{id}", HandleAsync)
            .WithName("Agencies: Update")
            .WithSummary("Atualiza uma agência")
            .WithDescription("Atualiza uma agência")
            .Produces<Response<Agency?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IAgencyHandler handler,
            UpdateAgencyRequest request,
            int id)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
