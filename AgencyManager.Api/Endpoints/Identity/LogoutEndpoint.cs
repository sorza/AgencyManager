using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace AgencyManager.Api.Endpoints.Identity
{
    public class LogoutEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/logout", HandleAsync)
            .RequireAuthorization();

        private static async Task<IResult> HandleAsync( SignInManager<User> signInManager)
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        }
    }
}
