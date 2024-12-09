using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Contracts
{
    public class DeleteContractEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapDelete("/{id}", HandleAsync)
            .WithName("Contracts: Delete")
            .WithSummary("Excui um contrato")
            .WithDescription("Exclui um contrato")
            .Produces<Response<ContractService?>>();

        private static async Task<IResult> HandleAsync(
             ClaimsPrincipal user, IContractHandler handler, int id)
        {
            var request = new DeleteContractServiceRequest
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
