namespace Carbook.Contracts;

public record UpdateCarRequest(CarType Type, string Make, string Model, DateOnly ProductionDate, int Mileage);