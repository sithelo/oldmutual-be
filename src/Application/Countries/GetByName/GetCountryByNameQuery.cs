using Application.Abstractions.Messaging;

namespace Application.Countries.GetByName;

public sealed record GetCountryByNameQuery(string Name) : IQuery<CountryResponse>;
