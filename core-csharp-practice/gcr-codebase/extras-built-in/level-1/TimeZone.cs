using System;
class TimeZone
{
    static void Main(string[] args)
    {
        DateTimeOffset utcTime = DateTimeOffset.UtcNow;

        TimeZoneInfo gmt = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        TimeZoneInfo ist = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        Console.WriteLine("Current Time in GMT: " +TimeZoneInfo.ConvertTime(utcTime, gmt));

        Console.WriteLine("Current Time in IST: " +TimeZoneInfo.ConvertTime(utcTime, ist));

        Console.WriteLine("Current Time in PST: " +TimeZoneInfo.ConvertTime(utcTime, pst));
    }
}