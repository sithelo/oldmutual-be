namespace Application.Countries.GetByName;

public sealed record CountryResponse
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    public string Flag { get; init; }

    public CountryDetails CountryDetails { get; init; }
}
public sealed record CountryResult
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    public string Flag { get; init; }

    public string CountryName { get; init; }
    public int Population { get; init; }
    public string City { get; init; }
}

