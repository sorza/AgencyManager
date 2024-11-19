using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Agencies
{
    public class GetAgencyByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/{id}", HandleAsync)
           .WithName("Agencies: Get By Id")
           .WithSummary("Recupera uma agência")
           .WithDescription("Recupera uma agência")
           .Produces<Response<Agency?>>();

        private static async Task<IResult> HandleAsync(
             IAgencyHandler handler, int id)
        {
            var request = new GetAgencyByIdRequest
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
