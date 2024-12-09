using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Models;
using AgencyManager.Core;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Contacts
{
    public class GetContactsByCompanyEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapGet("/company/{id}", HandleAsync)
               .WithName("Contacts: Get All By Company")
               .WithSummary("Busca contatos de uma empresa")
               .WithDescription("Busca contatos de uma empresa")
               .Produces<PagedResponse<List<Contact>?>>();

        private static async Task<IResult> HandleAsync(
             ClaimsPrincipal user,
             IContactHandler handler,
             int id,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetContactsByCompanyId
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize,
                ComapanyId = id
            };

            var result = await handler.GetAllByCompanyAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
