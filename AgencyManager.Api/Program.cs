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
using System.Text.Json;

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
    async (CreateAgencyRequest request,
    IAgencyHandler handler) => await handler.CreateAsync(request))
    .WithName("Agencies: Create")
    .WithSummary("Cria uma nova agência")
    .Produces<Response<Agency?>>();


app.MapGet("/v1/agencies/{id}",
    async (int id, IAgencyHandler handler) =>
    {
        var request = new GetAgencyByIdRequest { Id = id };
        return await handler.GetByIdAsync(request);
    })
    .WithName("Agencies: GetById")
    .WithSummary("Busca uma agência por Id")
    .Produces<Response<Agency?>>();


app.MapPut("/v1/agencies/{id}",
    async (int id, UpdateAgencyRequest request, IAgencyHandler handler) =>
    {
        request.Id = id;
        return await handler.UpdateAsync(request);
    })
    .WithName("Agencies: Update")
    .WithSummary("Atualiza dados de uma agência")
    .Produces<Response<Agency?>>();

app.MapDelete("/v1/agencies/{id}",
    async (int id, IAgencyHandler handler) =>
    {
        var request = new DeleteAgencyRequest
        {
            Id = id
        };        
        return await handler.DeleteAsync(request);
    })
    .WithName("Agencies: Delete")
    .WithSummary("Exlcui uma agência")
    .Produces<Response<Agency?>>();

app.Run();
