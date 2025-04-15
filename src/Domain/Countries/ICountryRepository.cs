namespace Domain.Countries;

public interface ICountryRepository
{
    Task<Country?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsCountryUniqueAsync(Name countryName);

    void Insert(Country country);
}
