using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Contacts
{
    public class DeleteContactEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapDelete("/{id}", HandleAsync)
               .WithName("Contacts: Delete")
               .WithSummary("Exclui um contato")
               .WithDescription("Exclui um contato")
               .Produces<Response<Contact?>>();

        private static async Task<IResult> HandleAsync(
             ClaimsPrincipal user, IContactHandler handler, int id)
        {
            var request = new DeleteContactRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.DeleteAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
