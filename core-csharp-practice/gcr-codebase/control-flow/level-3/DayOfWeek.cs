using System;
class DayOfWeek
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Month:");
        int Month = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Day:");
        int Day = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Year:");
        int Year = Convert.ToInt32(Console.ReadLine());

        int Y = Year-(14-Month)/12;
        int X = Y + Y/4 - Y/100 + Y/400;
        int M = Month + 12 *((14-Month)/12)-2;
        int D = ((Day + X + 31*M)/12)%7;

        Console.WriteLine(D);
    }
}