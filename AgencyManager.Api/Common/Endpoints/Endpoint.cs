using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Common.Endpoints.Agencies;
using AgencyManager.Api.Common.Endpoints.Contacts;
using AgencyManager.Api.Common.Endpoints.Employees;
using AgencyManager.Api.Common.Endpoints.Positions;
using AgencyManager.Core.Requests.Contact;

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

            endpoints.MapGroup("/v1/contacts")
                .WithTags("Contacts")
                .MapEndpoint<CreateContactEndpoint>()
                .MapEndpoint<UpdateContactEndpoint>()
                .MapEndpoint<DeleteContactEndpoint>()
                .MapEndpoint<GetContactsByAgencyEndpoint>()
                .MapEndpoint<GetContactsByCompanyEndpoint>()
                .MapEndpoint<GetContactsByEmployeeEndpoint>();

            endpoints.MapGroup("/v1/employees")
                .WithTags("Employees")
                .MapEndpoint<CreateEmployeeEndpoint>();

            endpoints.MapGroup("/v1/positions")
                .WithTags("Positions")
                .MapEndpoint<CreatePositionEndpoint>()
                .MapEndpoint<UpdatePositionEndpoint>()
                .MapEndpoint<DeletePositionEndpoint>();

        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
