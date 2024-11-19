using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Contacts
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
            IContactHandler handler,
            UpdateContactRequest request,
            int id)
        {
            request.UserId = "teste@teste.com";
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
