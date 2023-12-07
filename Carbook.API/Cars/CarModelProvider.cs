namespace Carbook.API.Cars;

public class CarModelProvider : ICarModelProvider
{
    private static readonly string[] Models = new[] {
        "BMW", "Audi", "Ford", "KIA", "Toyota"
    };
    
    public string GetRandomModel()
    {
        return Models[Random.Shared.Next(Models.Length)];
    }
}