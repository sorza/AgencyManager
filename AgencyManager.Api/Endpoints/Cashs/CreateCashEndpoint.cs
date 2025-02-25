﻿using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Cashs
{
    public class CreateCashEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
           .WithName("Cashs: Create")
           .WithSummary("Abre um novo caixa")
           .WithDescription("Abre um novo caixa")
           .Produces<Response<Cash?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICashHandler handler,
            CreateCashRequest request)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
