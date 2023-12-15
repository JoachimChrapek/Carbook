namespace Carbook.Contracts;

public record UpdateCarRequest(string Make, string Model, DateOnly ProductionDate, int Mileage);