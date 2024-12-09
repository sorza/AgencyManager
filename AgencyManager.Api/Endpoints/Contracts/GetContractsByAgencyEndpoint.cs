using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Responses;
using AgencyManager.Core;
using Microsoft.AspNetCore.Mvc;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Api.Models;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Contracts
{
    public class GetContractsByAgencyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/", HandleAsync)
           .WithName("Contracts: Get By Agency")
           .WithSummary("Recupera os contratos de uma agência")
           .WithDescription("Recupera os contratos de uma agência")
           .Produces<PagedResponse<List<ContractService>?>>();

        private static async Task<IResult> HandleAsync(
             ClaimsPrincipal user,
             IContractHandler handler,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllContractsByAgencyRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetByAgencyIdAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
