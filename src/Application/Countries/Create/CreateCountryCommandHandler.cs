using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Countries;
using SharedKernel;

namespace Application.Countries.Create;

public sealed class CreateCountryCommandHandler(
    ICountryRepository countryRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateCountryCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
#pragma warning disable CA1725
        CreateCountryCommand command,
#pragma warning restore CA1725
        CancellationToken cancellationToken)
    {
        Result<Name> countryNameResult = Name.Create(command.Name);
        if (countryNameResult.IsFailure)
        {
            return Result.Failure<Guid>(countryNameResult.Error);
        }

        Name name = countryNameResult.Value;
        if (!await countryRepository.IsCountryUniqueAsync(name))
        {
            return Result.Failure<Guid>(CountryErrors.CountryNameNotUnique);
        }

        var flag = new Flag(command.Flag);
        Result<Name> cityNameResult = Name.Create(command.City);
        if (cityNameResult.IsFailure)
        {
            return Result.Failure<Guid>(cityNameResult.Error);
        }
        Name city = cityNameResult.Value;
        var country = Country.Create( name, flag,  city, command.population);

        countryRepository.Insert(country);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return country.Id;
    }
}
