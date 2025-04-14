using SharedKernel;

namespace Domain.Countries;

public sealed record CountryCreatedDomainEvent(Guid countryId) : IDomainEvent;
