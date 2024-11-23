using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Common.Endpoints.Agencies;
using AgencyManager.Api.Common.Endpoints.Cashs;
using AgencyManager.Api.Common.Endpoints.Companies;
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
                .MapEndpoint<CreateEmployeeEndpoint>()
                .MapEndpoint<DeleteEmployeeEndpoint>()
                .MapEndpoint<GetAllEmployeesByAgencyEndpoint>()
                .MapEndpoint<GetEmployeeByIdEndpoint>()
                .MapEndpoint<UpdateEmployeeEndpoint>();

            endpoints.MapGroup("/v1/positions")
                .WithTags("Positions")
                .MapEndpoint<CreatePositionEndpoint>()
                .MapEndpoint<UpdatePositionEndpoint>()
                .MapEndpoint<DeletePositionEndpoint>()
                .MapEndpoint<GetPositionsByAgencyEndpoint>()
                .MapEndpoint<GetPositionByIdEndpoint>();

            endpoints.MapGroup("/v1/companies")
               .WithTags("Companies")  
               .MapEndpoint<CreateCompanyEndpoint>()
               .MapEndpoint<UpdateCompanyEndpoint>()
               .MapEndpoint<DeleteCompanyEndpoint>()
               .MapEndpoint<GetCompanyByIdEndpoint>()
               .MapEndpoint<GetAllCompaniesEndpoint>();

            endpoints.MapGroup("/v1/cashs")
               .WithTags("Cashs")
               .MapEndpoint<CreateCashEndpoint>()
               .MapEndpoint<UpdateCashEndpoint>()
               .MapEndpoint<DeleteCashEndpoint>()
               .MapEndpoint<GetCashByIdEndpoint>()
               .MapEndpoint<GetCashsByUserByPeriodEndpoint>()
               .MapEndpoint<GetCashsByAgencyByPeriodEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
