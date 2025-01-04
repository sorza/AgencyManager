using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AgencyManager.Web;
using MudBlazor.Services;
using AgencyManager.Web.Security;
using Microsoft.AspNetCore.Components.Authorization;
using AgencyManager.Core.Handlers;
using AgencyManager.Web.Handlers;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CookieHandler>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
builder.Services.AddScoped(x => (ICookieAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddMudServices();

builder.Services.AddHttpClient(Configuration.HttpClientName, opt =>
{
    opt.BaseAddress = new Uri(Configuration.BackendUrl);
}).AddHttpMessageHandler<CookieHandler>();

builder.Services.AddTransient<IAccountHandler, AccountHandler>();
builder.Services.AddTransient<IAgencyHandler, AgencyHandler>();
builder.Services.AddTransient<IContactHandler, ContactHandler>();
builder.Services.AddTransient<ICashHandler, CashHandler>();
builder.Services.AddTransient<ICompanyHandler, CompanyHandler>();
builder.Services.AddTransient<IContractHandler, ContractHandler>();
builder.Services.AddTransient<IEmployeeHandler, EmployeeHandler>();
builder.Services.AddTransient<ILocalityHandler, LocalityHandler>();
builder.Services.AddTransient<IPositionHandler, PositionHandler>();
builder.Services.AddTransient<ISaleHandler, SaleHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
builder.Services.AddTransient<IVirtualSaleHandler, VirtualSaleHandler>();


await builder.Build().RunAsync();
