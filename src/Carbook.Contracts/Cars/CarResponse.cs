namespace Carbook.Contracts;

public record CarResponse(Guid Id, CarType Type, string Make, string Model, DateOnly ProductionDate, int Mileage, DateTime LastModifiedDateTime);