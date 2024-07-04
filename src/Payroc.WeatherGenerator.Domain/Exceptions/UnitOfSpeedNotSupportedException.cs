namespace Payroc.WeatherGenerator.Domain.Exceptions;

public class UnitOfSpeedNotSupportedException : NotSupportedException
{
    public UnitOfSpeedNotSupportedException() : base() {}
    public UnitOfSpeedNotSupportedException(string message) : base(message) {}
}