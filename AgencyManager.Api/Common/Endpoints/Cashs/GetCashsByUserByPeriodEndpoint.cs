﻿using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;
using AgencyManager.Core;
using Microsoft.AspNetCore.Mvc;

namespace AgencyManager.Api.Common.Endpoints.Cashs
{
    public class GetCashsByUserByPeriodEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapGet("/userByPeriod/{id}", HandleAsync)
            .WithName("Cashs: Get by user and Period")
            .WithSummary("Recupera os caixas de um usuário por período")
            .WithDescription("Recupera os caixas de um usuário por período")
            .Produces<PagedResponse<List<Cash>?>>();

        private static async Task<IResult> HandleAsync(
             ICashHandler handler, string id,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetCashsByUserByPeriodRequest
            {
                Id = id,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetByUserByPeriodAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
