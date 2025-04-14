using Application.Abstractions.Messaging;

namespace Application.Countries.GetAll;

public sealed record GetAllCountriesQuery : IQuery<IReadOnlyCollection<CountryAllResponse>>;
