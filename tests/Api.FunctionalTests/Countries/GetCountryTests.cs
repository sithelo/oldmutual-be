using System.Net;
using System.Net.Http.Json;
using Api.FunctionalTests.Extensions;
using Api.FunctionalTests.Infrastructure;

using Application.Countries.GetByName;
using Application.Users.Create;
using FluentAssertions;

namespace Api.FunctionalTests.Countries;

public class GetCountryTests : BaseFunctionalTest
{
    public GetCountryTests(FunctionalTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task Should_ReturnNotFound_WhenCountryDoesNotExist()
    {
        // Arrange
        string name = GenerateRandomStringCountryNotExist.RandomString(15);

        // Act
        HttpResponseMessage response = await HttpClient.GetAsync($"api/v1/countries/{name}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task Should_ReturnCountry_WhenCountryExists()
    {
        // Arrange
        string countryName = await CreateCountryAsync();

        // Act
        CountryResponse? user = await HttpClient.GetFromJsonAsync<CountryResponse>($"api/v1/countries/{countryName}");

        // Assert
        user.Should().NotBeNull();
    }

    private async Task<string> CreateCountryAsync()
    {
        var request = new CreateCountryRequest("South Africa", "https://flagcdn.com/za.svg", "Pretoria", 59308690);

        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/v1/countries", request);

        return await response.Content.ReadFromJsonAsync<string>();
    }
}
