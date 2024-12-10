using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Endpoints.Agencies;
using AgencyManager.Api.Endpoints.Cashs;
using AgencyManager.Api.Endpoints.Companies;
using AgencyManager.Api.Endpoints.Contacts;
using AgencyManager.Api.Endpoints.Contracts;
using AgencyManager.Api.Endpoints.Employees;
using AgencyManager.Api.Endpoints.Identity;
using AgencyManager.Api.Endpoints.Localities;
using AgencyManager.Api.Endpoints.Positions;
using AgencyManager.Api.Endpoints.Sales;
using AgencyManager.Api.Endpoints.Transactions;
using AgencyManager.Api.Endpoints.VirtualSales;
using AgencyManager.Api.Models;
using AgencyManager.Core.Requests.Contact;

namespace AgencyManager.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup("/v1/agencies")
                .WithTags("Agencies")
                .RequireAuthorization()    
                .MapEndpoint<CreateAgencyEndpoint>()
                .MapEndpoint<UpdateAgencyEndpoint>()
                .MapEndpoint<DeleteAgencyEndpoint>()
                .MapEndpoint<GetAgencyByIdEndpoint>()
                .MapEndpoint<GetAllAgenciesEndpoint>();

            endpoints.MapGroup("/v1/contacts")
                .WithTags("Contacts")
                .RequireAuthorization()
                .MapEndpoint<CreateContactEndpoint>()
                .MapEndpoint<UpdateContactEndpoint>()
                .MapEndpoint<DeleteContactEndpoint>()
                .MapEndpoint<GetContactsByAgencyEndpoint>()
                .MapEndpoint<GetContactsByCompanyEndpoint>()
                .MapEndpoint<GetContactsByEmployeeEndpoint>();

            endpoints.MapGroup("/v1/employees")
                .WithTags("Employees")
                .RequireAuthorization()
                .MapEndpoint<CreateEmployeeEndpoint>()
                .MapEndpoint<DeleteEmployeeEndpoint>()
                .MapEndpoint<GetAllEmployeesByAgencyEndpoint>()
                .MapEndpoint<GetEmployeeByIdEndpoint>()
                .MapEndpoint<UpdateEmployeeEndpoint>();

            endpoints.MapGroup("/v1/positions")
                .WithTags("Positions")
                .RequireAuthorization()
                .MapEndpoint<CreatePositionEndpoint>()
                .MapEndpoint<UpdatePositionEndpoint>()
                .MapEndpoint<DeletePositionEndpoint>()
                .MapEndpoint<GetPositionsByAgencyEndpoint>()
                .MapEndpoint<GetPositionByIdEndpoint>();

            endpoints.MapGroup("/v1/companies")
               .WithTags("Companies")
               .RequireAuthorization()
               .MapEndpoint<CreateCompanyEndpoint>()
               .MapEndpoint<UpdateCompanyEndpoint>()
               .MapEndpoint<DeleteCompanyEndpoint>()
               .MapEndpoint<GetCompanyByIdEndpoint>()
               .MapEndpoint<GetAllCompaniesEndpoint>();

            endpoints.MapGroup("/v1/cashs")
               .WithTags("Cashs")
               .RequireAuthorization()
               .MapEndpoint<CreateCashEndpoint>()
               .MapEndpoint<UpdateCashEndpoint>()
               .MapEndpoint<DeleteCashEndpoint>()
               .MapEndpoint<GetCashByIdEndpoint>()
               .MapEndpoint<GetCashsByUserByPeriodEndpoint>()
               .MapEndpoint<GetCashsByAgencyByPeriodEndpoint>();

            endpoints.MapGroup("/v1/sales")
              .WithTags("Sales")
              .RequireAuthorization()
              .MapEndpoint<CreateSaleEndpoint>()
              .MapEndpoint<UpdateSaleEndpoint>()
              .MapEndpoint<DeleteSaleEndpoint>()
              .MapEndpoint<GetAllSalesByCashEndpoint>()
              .MapEndpoint<GetSaleByIdEndpoint>();

            endpoints.MapGroup("/v1/transactions")
              .WithTags("Transactions")
              .RequireAuthorization()
              .MapEndpoint<CreateTransactionEndpoint>()
              .MapEndpoint<UpdateTransactionEndpoint>()
              .MapEndpoint<DeleteTransactionEndpoint>()
              .MapEndpoint<GetTransactionByIdEndpoint>()
              .MapEndpoint<GetAllTransactionsByCashEndpoint>();

            endpoints.MapGroup("/v1/virtualSales")
              .WithTags("VirtualSales")
              .RequireAuthorization()
              .MapEndpoint<CreateVirtualSaleEndpoint>()
              .MapEndpoint<UpdateVirtualSaleEndpoint>()
              .MapEndpoint<DeleteVirtualSaleEndpoint>()
              .MapEndpoint<GetVirtualSaleByIdEndpoint>()
              .MapEndpoint<GetAllVirtualSalesByCashEndpoint>();

            endpoints.MapGroup("/v1/localities")
              .WithTags("Localities")
              .RequireAuthorization()
              .MapEndpoint<CreateLocalityEndpoint>()
              .MapEndpoint<UpdateLocalityEndpoint>()
              .MapEndpoint<DeleteLocalityEndpoint>()
              .MapEndpoint<GetLocalityByIdEndpoit>()
              .MapEndpoint<GetAllLocalitiesEndpoint>();

            endpoints.MapGroup("/v1/contracts")
             .WithTags("Contracts")
             .RequireAuthorization()
             .MapEndpoint<CreateContractEndpoint>()
             .MapEndpoint<UpdateContractEndpoint>()
             .MapEndpoint<DeleteContractEndpoint>()
             .MapEndpoint<GetContractsByAgencyEndpoint>()
             .MapEndpoint<GetContractByIdEndpoint>();

            endpoints.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapIdentityApi<User>();

            endpoints.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapEndpoint<LogoutEndpoint>()
                .MapEndpoint<GetRolesEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
