using Domain.Countries;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    public Task<Country?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Countries.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<bool> IsCountryUniqueAsync(Name countryName)
    {
        return !await context.Countries.AnyAsync(u => u.Name == countryName);
    }

    public void Insert(Country country)
    {
        context.Countries.Add(country);
    }
}
