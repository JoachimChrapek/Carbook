using Carbook.Domain.Cars;

namespace Carbook.Application.Common.Persistence;

public interface ICarsRepository
{
    void Add(Car car);
    void Update(Car car);
    void Delete(Guid id);
    
    Car? Get(Guid id);
    IEnumerable<Car> GetAll();
    bool IsCarAdded(Guid id);
}