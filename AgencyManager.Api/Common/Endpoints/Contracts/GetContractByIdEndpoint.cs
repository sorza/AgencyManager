using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Contracts
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
             IContractHandler handler, int id)
        {
            var request = new GetContractByIdRequest
            {
                UserId = "teste@teste.com",
                Id = id
            };

            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
