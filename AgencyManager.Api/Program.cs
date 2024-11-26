using AgencyManager.Api.Data;
using Microsoft.EntityFrameworkCore;
using AgencyManager.Core.Profiles;
using AgencyManager.Core.Handlers;
using AgencyManager.Api.Handler;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using AgencyManager.Api.Common.Endpoints;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var cnnString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

        builder.Services.AddDbContext<AppDbContext>(x =>
        {
            x.UseSqlServer(cnnString);
        });

        builder.Services.AddAutoMapper(typeof(AddressProfile).Assembly);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(n => n.FullName);           
        });

        builder.Services.AddTransient<IContactHandler, ContactHandler>();
        builder.Services.AddTransient<IAgencyHandler, AgencyHandler>();
        builder.Services.AddTransient<IEmployeeHandler, EmployeeHandler>();
        builder.Services.AddTransient<IPositionHandler, PositionHandler>();
        builder.Services.AddTransient<ICompanyHandler, CompanyHandler>();
        builder.Services.AddTransient<ICashHandler, CashHandler>();
        builder.Services.AddTransient<ISaleHandler, SaleHandler>();
        builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();


        builder.Services.Configure<JsonOptions>(options =>
        {
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        });

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapGet("/", () => new { message = "OK"});
        app.MapEndpoints();

        app.Run();
    }
}