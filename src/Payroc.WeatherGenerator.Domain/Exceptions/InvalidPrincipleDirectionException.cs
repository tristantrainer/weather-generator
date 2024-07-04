namespace Payroc.WeatherGenerator.Domain.Exceptions;

public class InvalidPrincipleDirectionException : Exception
{
    public InvalidPrincipleDirectionException() : base() {}
    public InvalidPrincipleDirectionException(string message) : base(message) {}
}
