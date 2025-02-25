﻿using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.VirtualSale;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.VirtualSales
{
    public class DeleteVirtualSaleEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
             => app.MapDelete("/{id}", HandleAsync)
             .WithName("Virtual Sales: Delete")
             .WithSummary("Exclui uma venda virtual")
             .WithDescription("Exclui uma venda virtual")
             .Produces<Response<VirtualSale?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IVirtualSaleHandler handler,
            int id)
        {
            var request = new DeleteVirtualSaleRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.DeleteAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
