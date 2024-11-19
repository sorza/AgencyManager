using AgencyManager.Api.Common.Api;
using AgencyManager.Core;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AgencyManager.Api.Common.Endpoints.Contacts
{
    public class GetContactsByEmployeeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapGet("/employee/{id}", HandleAsync)
               .WithName("Contacts: Get All By Employee")
               .WithSummary("Busca contatos de um colaborador")
               .WithDescription("Busca contatos de um colaborador")
               .Produces<PagedResponse<List<Contact>?>>();

        private static async Task<IResult> HandleAsync(
             IContactHandler handler,
             int id,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetContactsByEmployeeId
            {               
                UserId = "teste@teste.com",
                PageNumber = pageNumber,
                PageSize = pageSize,
                EmplooyeeId = id
            };

            var result = await handler.GetAllByEmployeeAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
