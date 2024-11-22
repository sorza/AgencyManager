using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Employees
{
    public class UpdateEmployeeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapPut("/{id}", HandleAsync)
              .WithName("Employees: Update")
              .WithSummary("Atualiza um colaborador")
              .WithDescription("Atualiza um colaborador")
              .Produces<Response<Employee?>>();

        private static async Task<IResult> HandleAsync(
            IEmployeeHandler handler,
            UpdateEmployeeRequest request,
            int id)
        {
            request.UserId = "teste@teste.com";
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
