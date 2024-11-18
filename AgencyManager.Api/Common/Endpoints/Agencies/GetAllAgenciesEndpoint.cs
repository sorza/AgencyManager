using AgencyManager.Api.Common.Api;
using AgencyManager.Core;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AgencyManager.Api.Common.Endpoints.Agencies
{
    public class GetAllAgenciesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/", HandleAsync)
           .WithName("Agencies: Get All")
           .WithSummary("Recupera todas as agências")
           .WithDescription("Recupera todas as agências")
           .WithOrder(5)
           .Produces<PagedResponse<List<Agency>?>>();

        private static async Task<IResult> HandleAsync(
             IAgencyHandler handler,
             [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery]int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllAgenciesRequest
            {
                UserId = "teste@teste.com",
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetAllAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
