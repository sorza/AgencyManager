using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Employees
{
    public class DeleteEmployeeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/id", HandleAsync)
            .WithName("Employee: Delete")
            .WithSummary("Exclui um colaborador")
            .WithDescription("Exclui um colaborador")
            .Produces<Response<Employee?>>();

        private static async Task<IResult> HandleAsync(
            IEmployeeHandler handler,
            int id)
        {
            var request = new DeleteEmployeeRequest
            {
                UserId = "teste@teste.com",
                Id = id
            };

            var result = await handler.DeleteAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
