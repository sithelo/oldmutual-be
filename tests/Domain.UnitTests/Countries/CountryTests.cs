using Domain.Countries;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.Countries;

public class CountryTests
{
    [Fact]
    public void Create_Should_CreateCountry_WhenNameIsValid()
    {
        // Arrange
        Name countryName = Name.Create("South Africa").Value;
        Name cityName = Name.Create("Pretoria").Value;
        var flag = new Flag("za");

        // Act
        var country = Country.Create(countryName, flag, cityName, 59308690);

        // Assert
        country.Should().NotBeNull();
    }
}
