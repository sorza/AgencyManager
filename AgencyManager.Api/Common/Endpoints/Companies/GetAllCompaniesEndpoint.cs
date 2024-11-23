using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Responses;
using AgencyManager.Core;
using Microsoft.AspNetCore.Mvc;
using AgencyManager.Core.Requests.Company;

namespace AgencyManager.Api.Common.Endpoints.Companies
{
    public class GetAllCompaniesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapGet("/", HandleAsync)
          .WithName("Companies: Get All")
          .WithSummary("Recupera todas as empresas")
          .WithDescription("Recupera todas as empresas")
          .Produces<PagedResponse<List<Company>?>>();

        private static async Task<IResult> HandleAsync(
             ICompanyHandler handler,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllCompaniesRequest
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
