namespace Payroc.WeatherGenerator.Core.Models;

public class Range<T> where T : IComparable<T>
{
    public T Min { get; }
    public T Max { get; }

    public Range(T min, T max)
    {
        if (min.CompareTo(max) > 0)
        {
            throw new ArgumentException("Min value must be less than or equal to Max value.");
        }

        Min = min;
        Max = max;
    }
}
