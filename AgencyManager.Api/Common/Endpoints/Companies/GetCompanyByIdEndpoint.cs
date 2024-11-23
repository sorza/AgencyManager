using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Companies
{
    public class GetCompanyByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapGet("/{id}", HandleAsync)
          .WithName("Companies: Get By Id")
          .WithSummary("Recupera uma empresa")
          .WithDescription("Recupera uma empresa")
          .Produces<Response<Company?>>();

        private static async Task<IResult> HandleAsync(
             ICompanyHandler handler, int id)
        {
            var request = new GetCompanyByIdRequest
            {
                UserId = "teste@teste.com",
                Id = id
            };

            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
