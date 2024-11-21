using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Positions
{
    public class UpdatePositionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
            .WithName("Positions: Update")
            .WithSummary("Atualiza um cargo")
            .WithDescription("Atualiza um cargo")
            .Produces<Response<Position?>>();

        private static async Task<IResult> HandleAsync(
            IPositionHandler handler,
            UpdatePositionRequest request,
            int id )
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
