using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Locality;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Localities
{
    public class GetLocalityByIdEndpoit : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/{id}", HandleAsync)
           .WithName("Localities: Get By Id")
           .WithSummary("Recupera uma localidade")
           .WithDescription("Recupera uma localidade")
           .Produces<Response<Locality?>>();

        private static async Task<IResult> HandleAsync(
             ILocalityHandler handler, int id)
        {
            var request = new GetLocalityByIdRequest
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
