using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Transaction;
using AgencyManager.Core.Responses;
using AgencyManager.Core;
using Microsoft.AspNetCore.Mvc;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.VirtualSale;

namespace AgencyManager.Api.Common.Endpoints.VirtualSales
{
    public class GetAllVirtualSalesByCashEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
       => app.MapGet("/cash/{id}", HandleAsync)
              .WithName("Virtual Sales: Get Virtual Sales By Cash")
              .WithSummary("Busca vendas virtuais de um caixa")
              .WithDescription("Busca vendas virtuais de um caixa")
              .Produces<PagedResponse<List<VirtualSale>?>>();

        private static async Task<IResult> HandleAsync(
            IVirtualSaleHandler handler, int id,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetVirtualSalesByCashIdRequest
            {
                UserId = "teste@teste.com",
                PageNumber = pageNumber,
                PageSize = pageSize,
                CashId = id
            };

            var result = await handler.GetAllByCashIdAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
