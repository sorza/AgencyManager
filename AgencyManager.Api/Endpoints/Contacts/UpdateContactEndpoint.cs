using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;
using System.Security.Claims;

namespace AgencyManager.Api.Endpoints.Contacts
{
    public class UpdateContactEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapPut("/{id}", HandleAsync)
               .WithName("Contacts: Update")
               .WithSummary("Atualiza um contato")
               .WithDescription("Atualiza um contato")
               .Produces<Response<Contact?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IContactHandler handler,
            UpdateContactRequest request,
            int id)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
