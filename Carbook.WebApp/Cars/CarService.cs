using Carbook.Contracts;
using System.Net.Http.Json;
using ContractsCarType = Carbook.Contracts.CarType;

namespace Carbook.WebApp.Cars;

public class CarService : ICarService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<CarService> _logger;

    private const string _apiAddress = "http://localhost:5216/Cars/";
    
    public CarService(IHttpClientFactory httpClientFactory, ILogger<CarService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }
    
    public async Task<CarResponse?> CreateCar(Car car)
    {
        string url = $"{_apiAddress}";
        HttpClient httpClient = _httpClientFactory.CreateClient();

        CreateCarRequest request = new((ContractsCarType) car.Type, car.Make, car.Model, car.ProductionDate, car.Mileage);
        HttpResponseMessage response;

        try
        {
            response = await httpClient.PostAsJsonAsync(url, request);
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

        CarResponse? carResponse = await response.Content.ReadFromJsonAsync<CarResponse>();
        return carResponse;
    }

    public async Task<CarResponse?> GetCar(Guid id)
    {
        string url = $"{_apiAddress}{id}";
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

        CarResponse? carResponse = await response.Content.ReadFromJsonAsync<CarResponse>();
        return carResponse;
    }

    public async Task<CarsCollectionResponse?> GetAllCars()
    {
        string url = $"{_apiAddress}all";
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

        CarsCollectionResponse? carResponse = await response.Content.ReadFromJsonAsync<CarsCollectionResponse>();
        return carResponse;
    }

    public async Task<CarResponse?> UpdateCar(Guid id, Car newCar)
    {
        string url = $"{_apiAddress}{id}";
        HttpClient httpClient = _httpClientFactory.CreateClient();

        UpdateCarRequest request = new((ContractsCarType) newCar.Type, newCar.Make, newCar.Model, newCar.ProductionDate, newCar.Mileage);
        HttpResponseMessage response;

        try
        {
            response = await httpClient.PutAsJsonAsync(url, request);
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

        CarResponse? carResponse = await response.Content.ReadFromJsonAsync<CarResponse>();
        return carResponse;
    }

    public async Task DeleteCar(Guid id)
    {
        string url = $"{_apiAddress}{id}";
        HttpClient httpClient = _httpClientFactory.CreateClient();

        HttpResponseMessage response;

        try
        {
            response = await httpClient.DeleteAsync(url);
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return;
        }
        
        // if (response.IsSuccessStatusCode == false)
        // {
        //     return;
        // }
    }
}