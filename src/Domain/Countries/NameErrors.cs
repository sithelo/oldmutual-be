using SharedKernel;

namespace Domain.Countries;

public static class NameErrors
{
    public static readonly Error Empty = Error.Problem("Name.Empty", "Name is empty");

    public static readonly Error InvalidFormat = Error.Problem(
        "Name.InvalidFormat", "Name format is invalid");
}
