namespace Payroc.WeatherGenerator.Domain.Exceptions;

public class SpeedOutOfRangeException : ArgumentOutOfRangeException
{
    public SpeedOutOfRangeException() : base() {}
    public SpeedOutOfRangeException(string message) : base(message) {}
}

