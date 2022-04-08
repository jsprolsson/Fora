global using Blazored.LocalStorage;
global using Fora.Client.Services.InterestService;
global using Fora.Shared;
global using Fora.Shared.DTO.InterestDtos;
global using Fora.Shared.DTO.ThreadDtos;
global using Fora.Shared.DTO.MessageDtos;
global using Fora.Client.Services.InterestService;
global using Fora.Client.Services.ThreadService;
global using Fora.Client.Services.MessageService;
global using Microsoft.AspNetCore.Components.Authorization;
global using System.Net.Http.Json;
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
builder.Services.AddScoped<IThreadService, ThreadService>();
builder.Services.AddScoped<IMessageService, MessageService>();

// ----- Auth
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
// -----
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
