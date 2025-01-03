using AgencyManager.Api.Common.Api;
using AgencyManager.Core;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Contacts
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
             ClaimsPrincipal user,
             IContactHandler handler,
             int id,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetContactsByEmployeeId
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize,
                EmployeeId = id
            };

            var result = await handler.GetAllByEmployeeAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
