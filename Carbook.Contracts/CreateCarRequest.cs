namespace Carbook.Contracts;

public record CreateCarRequest(CarType Type, string Make, string Model, DateOnly ProductionDate, int Mileage);