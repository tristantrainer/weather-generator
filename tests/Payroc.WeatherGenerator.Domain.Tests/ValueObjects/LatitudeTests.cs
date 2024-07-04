using Payroc.WeatherGenerator.Core.Extensions;
using Payroc.WeatherGenerator.Domain.Exceptions;
using Payroc.WeatherGenerator.Domain.ValueObjects;

namespace Payroc.WeatherGenerator.Domain.Tests.ValueObjects;

public class LatitudeTests
{
    #region Constructor

    [Fact]
    public void Constructor_ReturnsLatitude_WhenValueIsValid() 
    {
        // Arrange
        var value = new Random().NextDouble(Latitude.MaxValue, Latitude.MinValue);

        // Act
        var latitude = new Latitude(value);

        // Assert
        latitude
            .Should()
            .NotBeNull();

        latitude.Value
            .Should()
            .Be(value);
    }

    [Theory]
    [InlineData(90.1)]
    [InlineData(-90.1)]
    public void Constructor_ThrowsInvalidLatitudeException_WhenValueOutsideOfExpectedRange(float value) 
    {
        // Arrange

        // Act
        var createAction = () => new Latitude(value);

        // Assert
        createAction
            .Should()
            .ThrowExactly<LatitudeOutOfRangeException>();
    }

    #endregion
    
    #region Equals

    [Fact]
    public void Equals_ReturnsTrue_WhenCodesMatch() 
    {
        // Arrange 
        var value = new Random().NextDouble(Latitude.MaxValue, Latitude.MinValue);

        var lhs = new Latitude(value);
        var rhs = new Latitude(value);

        // Act
        var result = lhs.Equals(rhs);

        // Assert
        result.Should().BeTrue();
    }

    #endregion
}
