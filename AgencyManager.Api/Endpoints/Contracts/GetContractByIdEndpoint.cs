using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Contracts
{
    public class GetContractByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/{id}", HandleAsync)
           .WithName("Contracts: Get By Id")
           .WithSummary("Recupera um contrato")
           .WithDescription("Recupera um contrato")
           .Produces<Response<ContractService?>>();

        private static async Task<IResult> HandleAsync(
             ClaimsPrincipal user, IContractHandler handler, int id)
        {
            var request = new GetContractByIdRequest
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
