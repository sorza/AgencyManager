using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Employees
{
    public class CreateEmployeeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Employee: Create")
            .WithSummary("Cadastra um novo colaborador")
            .WithDescription("Cadastra um novo colaborador")
            .Produces<Response<Employee?>>();

        private static async Task<IResult> HandleAsync(
            IEmployeeHandler handler,
            CreateEmployeeRequest request)
        {
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
