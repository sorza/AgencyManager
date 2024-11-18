using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;
using System.Reflection.Metadata.Ecma335;

namespace AgencyManager.Api.Common.Endpoints.Agencies
{
    public class CreateAgencyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Agencies: Create")
            .WithSummary("Cria uma nova agência")
            .WithDescription("Cria uma nova agência")
            .WithOrder(1)
            .Produces<Response<Agency?>>();

        private static async Task<IResult> HandleAsync(
            IAgencyHandler handler,
            CreateAgencyRequest request)
        {
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
