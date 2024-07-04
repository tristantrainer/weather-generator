using Payroc.WeatherGenerator.Domain.Common;
using Payroc.WeatherGenerator.Domain.Exceptions;

namespace Payroc.WeatherGenerator.Domain.ValueObjects;

public sealed class Probability(int value) : ValueObject
{
    public const int MaxValue = 100;
    public const int MinValue = 0;

    public int Value { get; } = Validate(value);

    public static implicit operator int(Probability probability) => probability.Value;

    private static int Validate(int value) 
    {
        if(value < MinValue || value > MaxValue) {
            throw new ProbabilityOutOfRangeException($"{value} is outside the range of possible probabilities ({MinValue} - {MaxValue})");
        }

        return value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
