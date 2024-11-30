using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.VirtualSale;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.VirtualSales
{
    public class GetVirtualSaleByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
          .WithName("Virtual Sales: Get By Id")
          .WithSummary("Recupera uma venda virtual")
          .WithDescription("Recupera uma venda virtual")
          .Produces<Response<VirtualSale?>>();

        private static async Task<IResult> HandleAsync(
             IVirtualSaleHandler handler, int id)
        {
            var request = new GetVirtualSalesByIdRequest
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
