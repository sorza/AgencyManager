using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Models;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.VirtualSale;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.VirtualSales
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
            ClaimsPrincipal user,
            CreateVirtualSaleRequest request,
            IVirtualSaleHandler handler)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
