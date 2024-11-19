using AgencyManager.Api.Common.Api;
using AgencyManager.Core;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AgencyManager.Api.Common.Endpoints.Contacts
{
    public class GetContactsByAgencyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapGet("/agency/{id}", HandleAsync)
               .WithName("Contacts: Get All By Agency")
               .WithSummary("Busca contatos de uma agência")
               .WithDescription("Busca contatos de uma agência")
               .Produces<PagedResponse<List<Contact>?>>();

        private static async Task<IResult> HandleAsync(
             IContactHandler handler,
             int id,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetContactsByAgencyId
            {               
                UserId = "teste@teste.com",
                PageNumber = pageNumber,
                PageSize = pageSize,
                AgencyId = id
            };

            var result = await handler.GetAllByAgencyAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
