using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;
using AgencyManager.Core;
using Microsoft.AspNetCore.Mvc;
using AgencyManager.Core.Requests.Employee;

namespace AgencyManager.Api.Common.Endpoints.Employees
{
    public class GetAllEmployeesByAgencyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/agency/{id}", HandleAsync)
               .WithName("Employees: Get Employees By Agency")
               .WithSummary("Busca colaboradores de uma agência")
               .WithDescription("Busca colaboradores de uma agência")
               .Produces<PagedResponse<List<Employee>?>>();

        private static async Task<IResult> HandleAsync(
            IEmployeeHandler handler,
            int id,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllEmployeesByAgencyIdRequest
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
