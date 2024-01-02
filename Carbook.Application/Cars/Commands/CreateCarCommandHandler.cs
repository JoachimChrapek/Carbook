using Carbook.Application.Common.Persistence;
using Carbook.Domain.Cars;
using FazApp.Result;
using FluentValidation.Results;
using MediatR;

namespace Carbook.Application.Cars.Commands;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<Car>>
{
    private readonly ICarsRepository _carsRepository;

    public CreateCarCommandHandler(ICarsRepository carsRepository)
    {
        _carsRepository = carsRepository;
    }

    public async Task<Result<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        CreateCarCommandValidator validator = new ();
        ValidationResult? validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid == false)
        {
            return validationResult.Errors.Select(e => new Error(ErrorType.Validation, e.ErrorCode, e.ErrorMessage)).ToList();
        }
        
        //TODO some kind of car creator, car factory
        Car car = new (Guid.NewGuid(), request.Type, request.Make, request.Model, request.ProductionDate, request.Mileage, DateTime.UtcNow);
        
        await _carsRepository.AddCarAsync(car);
        return car;
    }
}