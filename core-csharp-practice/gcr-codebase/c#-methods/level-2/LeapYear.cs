using System;

class LeapYear
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a year:");
        int year = Convert.ToInt32(Console.ReadLine());

        if (year < 1582)
        {
            Console.WriteLine("Leap Year calculation is valid only for year >= 1582.");
        }

        bool isLeap = CalculateLeapYear(year);

        if(isLeap)
        {
            Console.WriteLine("Leap Year");
        }

        else
        {
            Console.WriteLine("Not a Leap Year");
        }
    }

    public static bool CalculateLeapYear(int year)
    {
        if((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
        {
            return true;
        }

        else{
            return false;
        }
    }
}
