using MedicalCareR1.Auth;
using MedicalCareR1.Client.Pages;
using MedicalCareR1.Client.Services;
using MedicalCareR1.Components;
using MedicalCareR1.Shared.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using System.Buffers.Text;

var builder = WebApplication.CreateBuilder(args);

// ✅ Primero los servicios de infraestructura base
builder.Services.AddHttpContextAccessor(); // ← debe estar aquí arriba

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// HttpClient tipado hacia el backend API
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];
if (string.IsNullOrWhiteSpace(apiBaseUrl))
    throw new InvalidOperationException(
        "ApiSettings:BaseUrl no encontrada en appsettings.json del Sever");
//Console.WriteLine($"=== Web BaseUrl: '{apiBaseUrl}'");
//builder.Services.AddHttpClient("AppApi", client => {
//    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]!);
//});
builder.Services.AddHttpClient<IMedicalCenter, MedicalCenterServicio>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl!);
});

builder.Services.AddAuthorizationCore();// Agrega servicios de autorización para Blazor WebAssembly
builder.Services.AddCascadingAuthenticationState();// Agrega el estado de autenticación en cascada para que los componentes puedan acceder a la información de autenticación
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthStateProvider>();

//builder.Services.AddScoped<IMedicalCenter, MedicalCenterServicio>();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MedicalCareR1.Client._Imports).Assembly);

app.Run();
