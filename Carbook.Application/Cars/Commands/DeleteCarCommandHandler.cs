using Carbook.Application.Common.Persistence;
using Carbook.Application.Errors.Cars;
using FazApp.Result;
using MediatR;

namespace Carbook.Application.Cars.Commands;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Result>
{
    private readonly ICarsRepository _carsRepository;

    public DeleteCarCommandHandler(ICarsRepository carsRepository)
    {
        _carsRepository = carsRepository;
    }

    public async Task<Result> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        if (await _carsRepository.IsCarAddedAsync(request.Id) == false)
        {
            return CarsErrorrs.CarNotFound(request.Id);
        }
        
        await _carsRepository.DeleteCarAsync(request.Id);
        return Result.Success;
    }
}