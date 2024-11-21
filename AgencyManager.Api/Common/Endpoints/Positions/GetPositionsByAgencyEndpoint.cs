using AgencyManager.Api.Common.Api;
using AgencyManager.Core;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AgencyManager.Api.Common.Endpoints.Positions
{
    public class GetPositionsByAgencyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/agency/{id}", HandleAsync)
               .WithName("Positions: Get Positions By Agency")
               .WithSummary("Busca cargos de uma agência")
               .WithDescription("Busca cargos de uma agência")
               .Produces<PagedResponse<List<Position>?>>();

        private static async Task<IResult> HandleAsync(
            IPositionHandler handler, 
            int id,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetPositionsByAgencyIdRequest
            {
                UserId = "teste@teste.com",
                PageNumber = pageNumber,
                PageSize = pageSize,
                AgencyId = id
            };

            var result = await handler.GetAllByAgencyIdAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
