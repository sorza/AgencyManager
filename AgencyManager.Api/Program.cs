using AgencyManager.Api.Endpoints;
using AgencyManager.Api.Common.Api;
using AgencyManager.Api;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddConfiguration();        
        builder.AddSecurity();     
        builder.AddDataContexts();
        builder.AddAutoMapper();
        builder.AddCrossOrign();
        builder.AddDocumentation();       
        builder.AddServices();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
            app.ConfigDevEnvironment();

        app.UseCors(ApiConfiguration.CorsPolicyName);
        app.UseSecurity();        
        app.MapEndpoints();

        app.Run();
    }
}