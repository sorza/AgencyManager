using AgencyManager.Api.Data;
using Microsoft.EntityFrameworkCore;
using AgencyManager.Core.Profiles;
using AgencyManager.Core.Handlers;
using AgencyManager.Api.Handler;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Responses;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

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
    x.CustomSchemaIds(n=>n.FullName);
});

builder.Services.AddTransient<IAgencyHandler, AgencyHandler>();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/v1/agencies",
    (CreateAgencyRequest request,
    IAgencyHandler handler) => handler.CreateAsync(request))
    .WithName("Agencies: Create")
    .WithSummary("Cria uma nova agência")
    .Produces<Response<Agency>>();

app.Run();
