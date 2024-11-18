using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Agencies
{
    public class UpdateAgencyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapPut("/{id}", HandleAsync)
            .WithName("Agencies: Update")
            .WithSummary("Atualiza uma agência")
            .WithDescription("Atualiza uma agência")
            .WithOrder(2)
            .Produces<Response<Agency?>>();

        private static async Task<IResult> HandleAsync(
            IAgencyHandler handler,
            UpdateAgencyRequest request,
            int id)
        {
            request.UserId = "teste@teste.com";
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
