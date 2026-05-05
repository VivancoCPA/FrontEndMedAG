using MedicalCareR1.Client.Services;
using MedicalCareR1.Shared.Contracts;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//var baseUrl = builder.Configuration["ExternalServices:MedicalCenterUrl"] ?? "http://localhost:5043/api/";

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddScoped< IMedicalCenter, MedicalCenterServicio>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
