namespace Payroc.WeatherGenerator.Domain.Exceptions;

public class TemperatureOutOfRangeException : ArgumentOutOfRangeException
{
    public TemperatureOutOfRangeException() : base() {}
    public TemperatureOutOfRangeException(string message) : base(message) {}
}

