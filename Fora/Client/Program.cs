global using Blazored.LocalStorage;
global using Fora.Shared.DTO;
global using Microsoft.AspNetCore.Components.Authorization;
global using Fora.Shared;
global using Fora.Shared.DTO;
global using Fora.Shared.DTO.InterestDtos;
global using Fora.Client.Services.InterestService;
using Fora.Client;
using Fora.Client.Services.AuthService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMudServices();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IInterestService, InterestService>();

// ----- Auth
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
// -----
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
