using AgencyManager.Api.Data;
using Microsoft.EntityFrameworkCore;
using AgencyManager.Core.Profiles;
using AgencyManager.Core.Handlers;
using AgencyManager.Api.Handler;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using AgencyManager.Api.Common.Endpoints;

internal class Program
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

        builder.Services.Configure<JsonOptions>(options =>
        {
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapGet("/", () => new { message = "OK"});
        app.MapEndpoints();

        app.Run();
    }
}