using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyApplication;
using MudBlazor.Services;
using MyApplication.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<SegmentService>();
builder.Services.AddScoped<ClientsService>();
builder.Services.AddSingleton(new Configuration 
{ 
    UrlBase = "https://nocodebackend-nocodebackend-stage.azurewebsites.net/api/v1/dataset/642745c1d90328e7c643cd66/",
    RouteClients = "611ed902fd5915f2ae005dbb",
    RouteSegments = "611edbd7fd5915f2ae005dc2/",
    _SecretKey = "6425f48dd90328e7c643c5a0"
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
