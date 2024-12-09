using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Contracts
{
    public class CreateContractEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
       => app.MapPost("/", HandleAsync)
           .WithName("Contracts: Create")
           .WithSummary("Cria um novo contrato")
           .WithDescription("Cria um novo contrato")
           .Produces<Response<ContractService?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IContractHandler handler,
            CreateContractServiceRequest request)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
