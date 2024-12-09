using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Models;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Employees
{
    public class GetEmployeeByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Employee: Get By Id")
            .WithSummary("Busca um colaborador pelo id")
            .WithDescription("Busca um colaborador pelo id")
            .Produces<Response<Employee?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IEmployeeHandler handler, int id)
        {
            var request = new GetEmployeeByIdRequest
            {
                Id = id,
                UserId = user.Identity?.Name ?? string.Empty,
            };

            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
