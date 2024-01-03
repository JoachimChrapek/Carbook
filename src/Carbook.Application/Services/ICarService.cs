using Carbook.Domain.Cars;
using FazApp.Result;

namespace Carbook.Application.Services;

public interface ICarService
{
    Task<Result> CreateCarAsync(Car newCar);
    Task<Result<Car>> GetCarAsync(Guid id);
    Task<Result<IEnumerable<Car>>> GetAllCarsAsync();
    Task<Result> UpdateCarAsync(Car updatedCar);
    Task<Result> DeleteCarAsync(Guid id);
}