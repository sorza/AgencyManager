using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Employees
{
    public class GetEmployeeByUsernameEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Employee: Get By Username")
            .WithSummary("Busca um colaborador pelo username")
            .WithDescription("Busca um colaborador pelo username")
            .Produces<Response<Employee?>>();
        
        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IEmployeeHandler handler)
        {
            var request = new GetEmployeeByUsernameRequest
            {
                Username = user.Identity?.Name ?? string.Empty
            };

            var result = await handler.GetByUsernameAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
