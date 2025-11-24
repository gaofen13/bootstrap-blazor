using BootstrapBlazor;
using BootstrapBlazor.Shared.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddBootstrapBlazor();

await builder.Build().RunAsync();
