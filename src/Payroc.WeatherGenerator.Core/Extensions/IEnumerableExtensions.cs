namespace Payroc.WeatherGenerator.Core.Extensions;

public static class IEnumerableExtensions
{
    public static T Sample<T>(this IEnumerable<T> enumerable) 
    {
        var array = enumerable.ToArray();
        var index = new Random().Next(0, array.Length);
        return array[index];
    }
}
