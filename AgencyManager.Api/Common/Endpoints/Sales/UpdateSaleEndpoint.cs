﻿using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Sale;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Sales
{
    public class UpdateSaleEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapPut("/{id}", HandleAsync)
           .WithName("Sales: Update")
           .WithSummary("Atualiza uma venda")
           .WithDescription("Atualiza uma venda")
           .Produces<Response<Sale?>>();

        private static async Task<IResult> HandleAsync(
            ISaleHandler handler,
            UpdateSaleRequest request,
            int id)
        {
            request.UserId = "teste@teste.com";
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}