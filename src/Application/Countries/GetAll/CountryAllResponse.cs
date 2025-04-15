namespace Application.Countries.GetAll;

public sealed record CountryAllResponse
{
    public string Name { get; init; }
    public string Flag { get; init; }
}
