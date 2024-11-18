using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Agencies
{
    public class DeleteAgencyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapDelete("/{id}", HandleAsync)
            .WithName("Agencies: Delete")
            .WithSummary("Excui uma agência")
            .WithDescription("Exclui uma agência")
            .WithOrder(3)
            .Produces<Response<Agency?>>();

        private static async Task<IResult> HandleAsync(
             IAgencyHandler handler, int id)
        {
            var request = new DeleteAgencyRequest
            {
                UserId = "teste@teste.com",
                Id = id
            };

            var result = await handler.DeleteAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
