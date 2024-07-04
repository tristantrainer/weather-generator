namespace Payroc.WeatherGenerator.Domain.Exceptions;

public class LongitudeOutOfRangeException : ArgumentOutOfRangeException
{
    public LongitudeOutOfRangeException() : base() {}

    public LongitudeOutOfRangeException(string message) : base(message) {}
}
