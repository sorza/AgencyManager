using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Common.Endpoints.Agencies;

namespace AgencyManager.Api.Common.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/v1/agencies")
                .WithTags("Agencies")
                //.RequireAuthorization()    
                .MapEndpoint<CreateAgencyEndpoint>()
                .MapEndpoint<UpdateAgencyEndpoint>()
                .MapEndpoint<DeleteAgencyEndpoint>()
                .MapEndpoint<GetAgencyByIdEndpoint>()
                .MapEndpoint<GetAllAgenciesEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
