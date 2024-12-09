using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Responses;
using AgencyManager.Core;
using Microsoft.AspNetCore.Mvc;
using AgencyManager.Core.Requests.Sale;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Sales
{
    public class GetAllSalesByCashEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/cash/{id}", HandleAsync)
               .WithName("Sales: Get Sales By Cash")
               .WithSummary("Busca vendas de um caixa")
               .WithDescription("Busca vendas de um caixa")
               .Produces<PagedResponse<List<Sale>?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ISaleHandler handler,
            int id,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetSalesByCashRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize,
                CashId = id
            };

            var result = await handler.GetAllByCashAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
