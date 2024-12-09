using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Models;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Companies
{
    public class DeleteCompanyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapDelete("/{id}", HandleAsync)
           .WithName("Companies: Delete")
           .WithSummary("Excui uma empresa")
           .WithDescription("Exclui uma empresa")
           .Produces<Response<Company?>>();

        private static async Task<IResult> HandleAsync(
             ClaimsPrincipal user, ICompanyHandler handler, int id)
        {
            var request = new DeleteCompanyRequest
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
