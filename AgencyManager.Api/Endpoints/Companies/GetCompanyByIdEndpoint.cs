using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Models;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Companies
{
    public class GetCompanyByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapGet("/{id}", HandleAsync)
          .WithName("Companies: Get By Id")
          .WithSummary("Recupera uma empresa")
          .WithDescription("Recupera uma empresa")
          .Produces<Response<Company?>>();

        private static async Task<IResult> HandleAsync(
             ClaimsPrincipal user, ICompanyHandler handler, int id)
        {
            var request = new GetCompanyByIdRequest
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
