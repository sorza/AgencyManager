﻿using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Locality;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Localities
{
    public class UpdateLocalityEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapPut("/{id}", HandleAsync)
            .WithName("Localities: Update")
            .WithSummary("Atualiza uma localidade")
            .WithDescription("Atualiza uma localidade")
            .Produces<Response<Locality?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ILocalityHandler handler,
            UpdateLocalityRequest request,
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
