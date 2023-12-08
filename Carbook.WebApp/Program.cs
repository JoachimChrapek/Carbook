using Carbook.Shared.Cars;
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

var app = builder.Build();

var carService = app.Services.GetRequiredService<ICarService>();

var cars = await carService.GetRandomCarsCollectionAsync(2);

if(cars != null)
{
    foreach (Car car in cars)
    {
        Console.WriteLine(car.ToString());
    }
}

await app.RunAsync();