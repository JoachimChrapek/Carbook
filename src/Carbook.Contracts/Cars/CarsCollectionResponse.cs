namespace Carbook.Contracts;

public record CarsCollectionResponse(IEnumerable<CarResponse> CarsCollection);