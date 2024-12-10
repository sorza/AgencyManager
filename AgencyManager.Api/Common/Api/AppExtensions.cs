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
        }
    }
}
