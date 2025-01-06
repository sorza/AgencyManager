using AgencyManager.Api.Common.Api;
using AgencyManager.Core;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Agencies
{
    public class GetAllAgenciesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/", HandleAsync)
           .WithName("Agencies: Get All")
           .WithSummary("Recupera todas as agências")
           .WithDescription("Recupera todas as agências")
           .Produces<PagedResponse<List<Agency>?>>();

        private static async Task<IResult> HandleAsync(
             ClaimsPrincipal user,
             IAgencyHandler handler,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllAgenciesRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetAllAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
