using AgencyManager.Api.Data;
using AgencyManager.Api.Handler;
using AgencyManager.Api.Models;
using AgencyManager.Core;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.Api.Common.Api
{
    public static class BuilderExtensions
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.ConnectionString = builder
                .Configuration
                .GetConnectionString("DefaultConnection")
            ?? string.Empty;
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });
        }

        public static void AddSecurity(this WebApplicationBuilder builder)
        {
            builder.Services
               .AddAuthentication(IdentityConstants.ApplicationScheme)
               .AddIdentityCookies();

            builder.Services.AddAuthorization();
        }

        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(x => { x.UseSqlServer(Configuration.ConnectionString);});

            builder.Services
                .AddIdentityCore<User>()
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddApiEndpoints();
        }

        public static void AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAutoMapper(typeof(AddressProfile).Assembly);
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IContactHandler, ContactHandler>();
            builder.Services.AddTransient<IAgencyHandler, AgencyHandler>();
            builder.Services.AddTransient<IEmployeeHandler, EmployeeHandler>();
            builder.Services.AddTransient<IPositionHandler, PositionHandler>();
            builder.Services.AddTransient<ICompanyHandler, CompanyHandler>();
            builder.Services.AddTransient<ICashHandler, CashHandler>();
            builder.Services.AddTransient<ISaleHandler, SaleHandler>();
            builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
            builder.Services.AddTransient<IVirtualSaleHandler, VirtualSaleHandler>();
            builder.Services.AddTransient<ILocalityHandler, LocalityHandler>();
            builder.Services.AddTransient<IContractHandler, ContractHandler>();
        }

        public static void AddCrossOrign(this WebApplicationBuilder builder) { }
    }
}
