using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Positions
{
    public class DeletePositionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
            .WithName("Positions: Delete")
            .WithSummary("Exclui um cargo")
            .WithDescription("Exclui um cargo")
            .Produces<Response<Position?>>();

        private static async Task<IResult> HandleAsync(
            IPositionHandler handler,            
            int id)
        {
            var request = new DeletePositionRequest
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
