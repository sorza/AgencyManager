using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Companies
{
    public class CreateCompanyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Companies: Create")
            .WithSummary("Cria uma nova empresa")
            .WithDescription("Cria uma nova empresa")
            .Produces<Response<Company?>>();

        private static async Task<IResult> HandleAsync(
            ICompanyHandler handler,
            CreateCompanyRequest request)
        {
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
