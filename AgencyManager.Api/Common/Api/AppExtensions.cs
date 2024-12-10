using AgencyManager.Api.Endpoints;
using AgencyManager.Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AgencyManager.Api.Common.Api
{
    public static class AppExtensions
    {
        public static void ConfigDevEnvironment(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger().RequireAuthorization();
        }

        public static void UseSecurity(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

           
            app.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapIdentityApi<User>();

            app.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapPost("/logout", async (
                    SignInManager<User> signInManager) =>
                {
                    await signInManager.SignOutAsync();
                    return Results.Ok();
                })
                .RequireAuthorization();

            app.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapPost("/roles", (ClaimsPrincipal user) =>
                {
                    if (user.Identity is null || !user.Identity.IsAuthenticated)
                        return Results.Unauthorized();

                    var identity = (ClaimsIdentity)user.Identity;
                    var roles = identity
                        .FindAll(identity.RoleClaimType)
                        .Select(c => new
                        {
                            c.Issuer,
                            c.OriginalIssuer,
                            c.Type,
                            c.Value,
                            c.ValueType
                        });
                    return TypedResults.Json(roles);
                })
                .RequireAuthorization();
        }
    }
}
