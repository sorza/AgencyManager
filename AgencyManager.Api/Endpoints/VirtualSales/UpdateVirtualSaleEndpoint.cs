using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.VirtualSale;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.VirtualSales
{
    public class UpdateVirtualSaleEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandleAsync)
                   .WithName("Virtual Sales: Update")
                   .WithSummary("Atualiza uma venda virtual")
                   .WithDescription("Atualiza uma venda virtual")
                   .Produces<Response<VirtualSale?>>();
        }

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IVirtualSaleHandler handler,
            UpdateVirtualSaleRequest request,
            int id)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
