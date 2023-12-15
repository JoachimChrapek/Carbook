namespace Carbook.Contracts;

public record CarResponse(Guid Id, string Make, string Model, DateOnly ProductionDate, int Mileage, DateTime LastModifiedDateTime);