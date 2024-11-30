using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Locality;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Localities
{
    public class DeleteLocalityEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapDelete("/{id}", HandleAsync)
            .WithName("Localities: Delete")
            .WithSummary("Excui uma localidade")
            .WithDescription("Exclui uma localidade")
            .Produces<Response<Locality?>>();

        private static async Task<IResult> HandleAsync(
             ILocalityHandler handler, int id)
        {
            var request = new DeleteLocalityRequest
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
