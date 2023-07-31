using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASM;
using BlazorWASM.Auth;
using BlazorWASM.Services;
using BlazorWASM.Services.Http;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Auth;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<IPostService, PostHttpClient>();
builder.Services.AddScoped<ILocationService, LocationHttpClient>();
builder.Services.AddScoped<ICategoryService, CategoryHttpClient>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7093") });
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<IMessageService, MessageHttpClient>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
AuthorizationPolicies.AddPolicies(builder.Services);
builder.Services.AddScoped(sp => new HttpClient());
builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();
