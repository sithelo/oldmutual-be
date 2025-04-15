using FluentValidation;

namespace Application.Countries.Create;

internal sealed class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithErrorCode(CountryErrorCodes.CreateCountry.MissingName);

        RuleFor(c => c.City)
            .NotEmpty().WithErrorCode(CountryErrorCodes.CreateCountry.MissingName);
    }
}
