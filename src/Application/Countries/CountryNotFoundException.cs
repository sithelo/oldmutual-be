namespace Application.Countries;

public sealed class CountryNotFoundException : Exception
{
    public CountryNotFoundException(Guid countryId)
        : base($"The country with the identifier {countryId} was not found")
    {
        CountryId = countryId;
    }

    public Guid CountryId { get; }
}
