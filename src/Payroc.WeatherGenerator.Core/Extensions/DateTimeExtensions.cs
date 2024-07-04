namespace Payroc.WeatherGenerator.Core.Extensions;

public static class DateTimeExtensions
{
    public static DateTime AsOfPreviousHour(this DateTime dateTime) 
    {
        return dateTime
            .AddMinutes(-dateTime.Minute)
            .AddSeconds(-dateTime.Second)
            .AddMilliseconds(-dateTime.Millisecond)
            .AddMicroseconds(-dateTime.Microsecond);
    }
}
