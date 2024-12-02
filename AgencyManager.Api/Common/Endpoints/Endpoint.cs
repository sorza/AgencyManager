using AgencyManager.Api.Common.Api;
using AgencyManager.Api.Common.Endpoints.Agencies;
using AgencyManager.Api.Common.Endpoints.Cashs;
using AgencyManager.Api.Common.Endpoints.Companies;
using AgencyManager.Api.Common.Endpoints.Contacts;
using AgencyManager.Api.Common.Endpoints.Contracts;
using AgencyManager.Api.Common.Endpoints.Employees;
using AgencyManager.Api.Common.Endpoints.Localities;
using AgencyManager.Api.Common.Endpoints.Positions;
using AgencyManager.Api.Common.Endpoints.Sales;
using AgencyManager.Api.Common.Endpoints.Transactions;
using AgencyManager.Api.Common.Endpoints.VirtualSales;
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

            endpoints.MapGroup("/v1/sales")
              .WithTags("Sales")
              .MapEndpoint<CreateSaleEndpoint>()
              .MapEndpoint<UpdateSaleEndpoint>()
              .MapEndpoint<DeleteSaleEndpoint>()
              .MapEndpoint<GetAllSalesByCashEndpoint>()
              .MapEndpoint<GetSaleByIdEndpoint>();

            endpoints.MapGroup("/v1/transactions")
              .WithTags("Transactions")
              .MapEndpoint<CreateTransactionEndpoint>()
              .MapEndpoint<UpdateTransactionEndpoint>()
              .MapEndpoint<DeleteTransactionEndpoint>()
              .MapEndpoint<GetTransactionByIdEndpoint>()
              .MapEndpoint<GetAllTransactionsByCashEndpoint>();

            endpoints.MapGroup("/v1/virtualSales")
              .WithTags("VirtualSales")
              .MapEndpoint<CreateVirtualSaleEndpoint>()
              .MapEndpoint<UpdateVirtualSaleEndpoint>()
              .MapEndpoint<DeleteVirtualSaleEndpoint>()
              .MapEndpoint<GetVirtualSaleByIdEndpoint>()
              .MapEndpoint<GetAllVirtualSalesByCashEndpoint>();

            endpoints.MapGroup("/v1/localities")
              .WithTags("Localities")
              .MapEndpoint<CreateLocalityEndpoint>()
              .MapEndpoint<UpdateLocalityEndpoint>()
              .MapEndpoint<DeleteLocalityEndpoint>()
              .MapEndpoint<GetLocalityByIdEndpoit>()
              .MapEndpoint<GetAllLocalitiesEndpoint>();

            endpoints.MapGroup("/v1/contracts")
             .WithTags("Contracts")
             .MapEndpoint<CreateContractEndpoint>()
             .MapEndpoint<UpdateContractEndpoint>()
             .MapEndpoint<DeleteContractEndpoint>()
             .MapEndpoint<GetContractsByAgencyEndpoint>()
             .MapEndpoint<GetContractByIdEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
