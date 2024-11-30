using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Responses;
using AgencyManager.Core;
using Microsoft.AspNetCore.Mvc;
using AgencyManager.Core.Requests.Locality;

namespace AgencyManager.Api.Common.Endpoints.Localities
{
    public class GetAllLocalitiesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/", HandleAsync)
           .WithName("Localities: Get All")
           .WithSummary("Recupera todas as localidades")
           .WithDescription("Recupera todas as localidades")
           .Produces<PagedResponse<List<Locality>?>>();

        private static async Task<IResult> HandleAsync(
             ILocalityHandler handler,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllLocalitiesRequest
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
