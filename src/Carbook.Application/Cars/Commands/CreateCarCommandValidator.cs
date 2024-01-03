using FluentValidation;

namespace Carbook.Application.Cars.Commands;

//TODO temp, validate cars using existing database containing models, years of production etc
public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(c => c.Make)
            .MinimumLength(2)
            .MaximumLength(25);
        RuleFor(c => c.Model)
            .MinimumLength(2)
            .MaximumLength(25);

        RuleFor(c => c.ProductionDate)
            .InclusiveBetween(new DateOnly(1970, 1, 1), DateOnly.FromDateTime(DateTime.Now));

        RuleFor(c => c.Mileage)
            .InclusiveBetween(5, 5000000);
    }
}