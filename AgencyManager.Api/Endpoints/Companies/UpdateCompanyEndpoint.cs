﻿using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Companies
{
    public class UpdateCompanyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapPut("/{id}", HandleAsync)
            .WithName("Companies: Update")
            .WithSummary("Atualiza uma empresa")
            .WithDescription("Atualiza uma empresa")
            .Produces<Response<Company?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICompanyHandler handler,
            UpdateCompanyRequest request,
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
