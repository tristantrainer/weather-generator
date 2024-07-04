namespace Payroc.WeatherGenerator.Domain.Exceptions;

public class ProbabilityOutOfRangeException : ArgumentOutOfRangeException
{
    public ProbabilityOutOfRangeException() : base() {}

    public ProbabilityOutOfRangeException(string message) : base(message) {}
}