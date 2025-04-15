using SharedKernel;

namespace Domain.Countries;

public static class CountryErrors
{
    public static Error NotFound(Guid userId) => Error.NotFound(
        "Countries.NotFound",
        $"The user with the Id = '{userId}' was not found");

    public static readonly Error NotFoundByName = Error.NotFound(
        "Countries.NotFoundByName",
        "The country with the specified name was not found");

    public static readonly Error CountryNameNotUnique = Error.Conflict(
        "Countries.NameNotUnique",
        "The provided name is not unique");
}
