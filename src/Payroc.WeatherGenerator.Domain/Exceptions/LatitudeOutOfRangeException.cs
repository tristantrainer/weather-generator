namespace Payroc.WeatherGenerator.Domain.Exceptions;

public class LatitudeOutOfRangeException : ArgumentOutOfRangeException
{
    public LatitudeOutOfRangeException() : base() {}
    public LatitudeOutOfRangeException(string message) : base(message) {}
}
