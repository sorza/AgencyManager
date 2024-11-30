using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.VirtualSale;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.VirtualSales
{
    public class CreateVirtualSaleEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
                => app.MapPost("/", HandleAsync)
                .WithName("VirtualSales: Create")
                .WithSummary("Cadastra uma nova venda virtual")
                .WithDescription("Cadastra uma nova venda virtual")
                .Produces<Response<VirtualSale?>>();

        private static async Task<IResult> HandleAsync(
            CreateVirtualSaleRequest request,
            IVirtualSaleHandler handler)
        {
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
