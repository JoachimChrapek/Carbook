namespace Carbook.Contracts;

public record CreateCarRequest(string Make, string Model, DateOnly ProductionDate, int Mileage);