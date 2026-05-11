using MedicalCareR1.Client.Auth;
using MedicalCareR1.Client.Services;
using MedicalCareR1.Shared.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"]!;

if (string.IsNullOrWhiteSpace(apiBaseUrl))
    throw new InvalidOperationException(
        "ApiSettings:BaseUrl no encontrada en appsettings.json del Client");

// Registro correcto con AddHttpClient
//builder.Services.AddHttpClient("AppApi", client =>
//{
//    client.BaseAddress = new Uri(apiBaseUrl);
//});
builder.Services.AddHttpClient<IMedicalCenter, MedicalCenterServicio>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});
builder.Services.AddHttpClient<ICatalogoService, CatalogoApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl!);
});
builder.Services.AddHttpClient<IEspecialidadService, EspecialidadService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl!);
});
builder.Services.AddHttpClient<ITipoCentroService, TipoCentrroServicio>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl!);
});

// Cliente para APIs externas (sin BaseAddress fija)
builder.Services.AddHttpClient("Externo");

builder.Services.AddAuthorizationCore();// Agrega servicios de autorización para Blazor WebAssembly
builder.Services.AddCascadingAuthenticationState();// Agrega el estado de autenticación en cascada para que los componentes puedan acceder a la información de autenticación
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthStateProvider>();

builder.Services.AddMudServices();


await builder.Build().RunAsync();
