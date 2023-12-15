﻿using Carbook.Domain.Cars;

namespace Carbook.Application.Services;

public interface ICarService
{
    void CreateCar(Car newCar);
    Car? GetCar(Guid id);
    IEnumerable<Car> GetAllCars();
    void UpdateCar(Car updatedCar);
    void DeleteCar(Guid id);
}