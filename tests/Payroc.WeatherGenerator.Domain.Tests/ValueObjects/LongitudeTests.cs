using Payroc.WeatherGenerator.Core.Extensions;
using Payroc.WeatherGenerator.Domain.Exceptions;
using Payroc.WeatherGenerator.Domain.ValueObjects;

namespace Payroc.WeatherGenerator.Domain.Tests.ValueObjects;

public class LongitudeTests
{
    #region Constructor

    [Fact]
    public void Constructor_ReturnsLongitude_WhenValueIsValid() 
    {
        // Arrange
        var value = new Random().NextDouble(Longitude.MaxValue, Longitude.MinValue);

        // Act
        var longitude = new Longitude(value);

        // Assert
        longitude
            .Should()
            .NotBeNull();

        longitude.Value
            .Should()
            .Be(value);
    }

    [Theory]
    [InlineData(180.1)]
    [InlineData(-180.1)]
    public void Constructor_ThrowsInvalidLongitudeException_WhenValueOutsideOfExpectedRange(double value) 
    {
        // Arrange

        // Act
        var createAction = () => new Longitude(value);

        // Assert
        createAction
            .Should()
            .ThrowExactly<LongitudeOutOfRangeException>();
    }

    #endregion

    #region Equals

    [Fact]
    public void Equals_ReturnsTrue_WhenCodesMatch() 
    {
        // Arrange 
        var value = new Random().NextDouble(Longitude.MaxValue, Longitude.MinValue);

        var lhs = new Longitude(value);
        var rhs = new Longitude(value);

        // Act
        var result = lhs.Equals(rhs);

        // Assert
        result.Should().BeTrue();
    }

    #endregion
}
