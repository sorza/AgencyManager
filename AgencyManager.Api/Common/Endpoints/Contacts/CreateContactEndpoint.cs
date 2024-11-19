using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Contacts
{
    public class CreateContactEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Contacts: Create")
            .WithSummary("Cria um novo contato")
            .WithDescription("Cria um novo contato")
            .Produces<Response<Contact?>>();

        private static async Task<IResult> HandleAsync(
            IContactHandler handler,
            CreateContactRequest request)
        {
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
