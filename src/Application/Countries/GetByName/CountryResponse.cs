namespace Application.Countries.GetByName;

public sealed record CountryResponse
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    public string Flag { get; init; }

    public CountryDetails CountryDetails { get; init; }
}
