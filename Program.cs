using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DutyAndConductorManager.Web;
using MudBlazor.Services;
using DutyAndConductorManager.Web.Services;
using DutyAndConductorManager.Web.Helpers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["apiUrl"]) });
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<IThemeLibrary, ThemeLibrary>();
builder.Services.AddMudServices();

var host = builder.Build();

var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
await authenticationService.Initialize();

await host.RunAsync();
