using Carbook.Application.Cars.Commands;
using Carbook.Application.Common.Behaviours;
using Carbook.Domain.Cars;
using FazApp.Result;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Carbook.Application.Tests.Unit;

public class ValidationBehaviourTests
{
    private readonly ValidationBehaviour<CreateCarCommand, Result<Car>> _sut;
    
    private readonly IValidator<CreateCarCommand> _mockValidator = Substitute.For<IValidator<CreateCarCommand>>();
    private readonly RequestHandlerDelegate<Result<Car>> _mockNextBehaviour = Substitute.For<RequestHandlerDelegate<Result<Car>>>();

    public ValidationBehaviourTests()
    {
        _sut = new ValidationBehaviour<CreateCarCommand, Result<Car>>(_mockValidator);
    }
    
    [Fact]
    public async Task Handle_ShouldInvokeNextBahaviour_WhenValidationResultIsValid()
    {
        // Arrange
        CreateCarCommand createCarCommand = new (default, string.Empty, String.Empty, DateOnly.FromDateTime(DateTime.Now), 0);
        Car car = new (Guid.NewGuid(), default, string.Empty, String.Empty, DateOnly.FromDateTime(DateTime.Now), 0, DateTime.Now);

        _mockValidator.ValidateAsync(createCarCommand).Returns(new ValidationResult());
        _mockNextBehaviour.Invoke().Returns(car);
        
        // Act
        Result<Car> result = await _sut.Handle(createCarCommand, _mockNextBehaviour, default);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(car);
    }
    
    [Fact]
    public async Task Handle_ShouldReturnListOfErrors_WhenValidationResultIsNotValid()
    {
        // Arrange
        CreateCarCommand createCarCommand = new (default, string.Empty, String.Empty, DateOnly.FromDateTime(DateTime.Now), 0);

        ValidationFailure validationFailure = new("Unknown", "Unexpected errors has occured");
        ValidationResult failedValidationResult = new (new List<ValidationFailure> {validationFailure});
        _mockValidator.ValidateAsync(createCarCommand).Returns(failedValidationResult);
        
        // Act
        Result<Car> result = await _sut.Handle(createCarCommand, _mockNextBehaviour, default);

        // Assert
        result.IsError.Should().BeTrue();
        result.Errors.First().Code.Should().Be(validationFailure.PropertyName);
        result.Errors.First().Description.Should().Be(validationFailure.ErrorMessage);
    }
    
    [Fact]
    public async Task Handle_ShouldInvokeNextBahaviour_WhenValidatorIsNull()
    {
        // Arrange
        CreateCarCommand createCarCommand = new (default, string.Empty, String.Empty, DateOnly.FromDateTime(DateTime.Now), 0);
        Car car = new (Guid.NewGuid(), default, string.Empty, String.Empty, DateOnly.FromDateTime(DateTime.Now), 0, DateTime.Now);

        //TODO Duplicate of _sut
        ValidationBehaviour<CreateCarCommand, Result<Car>> validationBehaviour = new ();
        _mockNextBehaviour.Invoke().Returns(car);
        
        // Act
        Result<Car> result = await validationBehaviour.Handle(createCarCommand, _mockNextBehaviour, default);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(car);
    }
}