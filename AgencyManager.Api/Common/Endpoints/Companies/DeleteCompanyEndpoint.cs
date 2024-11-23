using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Companies
{
    public class DeleteCompanyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapDelete("/{id}", HandleAsync)
           .WithName("Companies: Delete")
           .WithSummary("Excui uma empresa")
           .WithDescription("Exclui uma empresa")
           .Produces<Response<Company?>>();

        private static async Task<IResult> HandleAsync(
             ICompanyHandler handler, int id)
        {
            var request = new DeleteCompanyRequest
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
