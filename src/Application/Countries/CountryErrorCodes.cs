namespace Application.Countries;

public static class CountryErrorCodes
{
    public static class CreateCountry
    {
        public const string MissingName = nameof(MissingName);
        public const string InvalidCountry = nameof(InvalidCountry);
    }
}
