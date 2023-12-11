namespace Carbook.Shared.Contract;

public class CarsCollectionResponse
{
    public IEnumerable<CarResponse> CarsCollection { get; }
    
    public CarsCollectionResponse(IEnumerable<CarResponse> carsCollection)
    {
        CarsCollection = carsCollection;
    }
}