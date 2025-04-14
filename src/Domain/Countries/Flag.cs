using SharedKernel;

namespace Domain.Countries;

public sealed record Flag
{
    public Flag(string? value)
    {
        Ensure.NotNullOrEmpty(value);

        Value = value;
    }

    public string Value { get; }
}
