using FazApp.Result;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Carbook.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : IResult
    
{
    private readonly IValidator<TRequest> _validator;

    public ValidationBehaviour(IValidator<TRequest> validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationResult? validationResult = await _validator.ValidateAsync(request, cancellationToken);
        
        if (validationResult.IsValid == false)
        {
            List<Error> errors =  validationResult.Errors.Select(e => new Error(ErrorType.Validation, e.ErrorCode, e.ErrorMessage)).ToList();
            return (dynamic)errors;
        }

        return await next();
    }
}