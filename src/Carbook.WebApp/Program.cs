using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Carbook.WebApp;
using Carbook.WebApp.Cars;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient();
builder.Services.AddSingleton<ICarService, CarService>();

builder.Services.AddScoped(sp => new HttpClient {
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddBlazoredModal();

var app = builder.Build();

await app.RunAsync();