using Carbook.Shared.Cars;
using System.Net.Http.Json;

namespace Carbook.WebApp.Cars;

public class CarService : ICarService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<CarService> _logger;

    public CarService(IHttpClientFactory httpClientFactory, ILogger<CarService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<IEnumerable<Car>?> GetRandomCarsCollectionAsync(int count)
    {
        _logger.LogInformation("Start get");
        
        string url = $"http://localhost:5216/Car/RandomCarsCollection/{count}";
        HttpClient httpClient = _httpClientFactory.CreateClient();

        HttpResponseMessage response;
        
        try
        {
            response = await httpClient.GetAsync(url);
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return null;
        }
        
        if (response.IsSuccessStatusCode == false)
        {
            return null;
        }

        IEnumerable<Car>? cars = await response.Content.ReadFromJsonAsync<IEnumerable<Car>>();
        
        _logger.LogInformation("get content");
        return cars;
    }
}