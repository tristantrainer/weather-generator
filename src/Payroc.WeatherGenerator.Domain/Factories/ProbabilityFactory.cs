using Payroc.WeatherGenerator.Core.Extensions;
using Payroc.WeatherGenerator.Domain.ValueObjects;

namespace Payroc.WeatherGenerator.Domain.Factories
{
    public class ProbabilityFactory
    {
        public static Probability CreateRandom() 
        {
            return new Probability(new Random().Next(Probability.MinValue, Probability.MaxValue));
        }
    }
}