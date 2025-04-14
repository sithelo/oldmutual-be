using Domain.Countries;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.Countries;

public class FlagTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Flag_Should_ThrowArgumentException_WhenValueIsInvalid(string? value)
    {
        // Act
        Flag Action() => new(value);

        // Assert
        FluentActions.Invoking(Action).Should().Throw<ArgumentNullException>()
            .Which
            .ParamName.Should().Be("value");
    }  
}
