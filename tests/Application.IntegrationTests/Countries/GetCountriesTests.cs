using Application.Countries.GetAll;
using Application.Countries.GetByName;
using Application.IntegrationTests.Infrastructure;
using Domain.Countries;
using FluentAssertions;
using SharedKernel;

namespace Application.IntegrationTests.Countries;

public class GetCountriesTests : BaseIntegrationTest
{
    public GetCountriesTests(IntegrationTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task Should_ReturnFailure_WhenCountryDoesNotExist()
    {
        // Arrange
        var query = new GetCountryByNameQuery("yryururu");

        // Act
        Result result = await Sender.Send(query);

        // Assert
        result.Error.Should().Be(CountryErrors.NotFoundByName);
    }

    [Fact]
    public async Task Should_ReturnCustomer_WhenCountriesDoesNotExists()
    {
        // Arrange

        var query = new GetAllCountriesQuery();

        // Act
        Result<IReadOnlyCollection<CountryAllResponse>> result  = await Sender.Send(query);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
    }
}
