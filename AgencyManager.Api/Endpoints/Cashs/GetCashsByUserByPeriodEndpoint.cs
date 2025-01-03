using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;
using AgencyManager.Core;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Cashs
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
             ClaimsPrincipal user,
             ICashHandler handler, string id,
             [FromQuery] DateTime? startDate = null,
             [FromQuery] DateTime? endDate = null,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetCashsByUserByPeriodRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id,
                PageNumber = pageNumber,
                PageSize = pageSize,
                StartDate = startDate,
                EndDate = endDate
            };

            var result = await handler.GetByUserByPeriodAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
