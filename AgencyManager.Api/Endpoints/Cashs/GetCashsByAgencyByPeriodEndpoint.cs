using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Responses;
using AgencyManager.Core;
using Microsoft.AspNetCore.Mvc;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Api.Models;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Cashs
{
    public class GetCashsByAgencyByPeriodEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapGet("/agencyByPeriod/{id}", HandleAsync)
            .WithName("Cashs: Get by Agency and Period")
            .WithSummary("Recupera os caixas de uma agência por período")
            .WithDescription("Recupera os caixas de uma agência por período")
            .Produces<PagedResponse<List<Cash>?>>();

        private static async Task<IResult> HandleAsync(
             ClaimsPrincipal user,
             ICashHandler handler, int id,
             [FromQuery] DateTime? startDate = null,
             [FromQuery] DateTime? endDate = null,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetCashsByAgencyByPeriodRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize,
                AgencyId = id,
                StartDate = startDate,
                EndDate = endDate
            };

            var result = await handler.GetByAgencyByPeriodAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
