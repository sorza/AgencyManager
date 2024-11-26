using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Sale;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Sales
{
    public class CreateSaleEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Sales: Create")
            .WithSummary("Cadastra uma nova venda")
            .WithDescription("Cadastra uma nova venda")
            .Produces<Response<Sale?>>();

        private static async Task<IResult> HandleAsync(
            CreateSaleRequest request,
            ISaleHandler handler)
        {
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
