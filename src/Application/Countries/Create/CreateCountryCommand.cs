using Application.Abstractions.Messaging;

namespace Application.Countries.Create;

public sealed record CreateCountryCommand(string Name, string Flag, string City, int population)
    : ICommand<Guid>;
