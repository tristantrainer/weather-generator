namespace Payroc.WeatherGenerator.Domain.Exceptions;

public class UnitOfTemperatureNotSupportedException : NotSupportedException
{
    public UnitOfTemperatureNotSupportedException() : base() {}
    public UnitOfTemperatureNotSupportedException(string message) : base(message) {}
}
