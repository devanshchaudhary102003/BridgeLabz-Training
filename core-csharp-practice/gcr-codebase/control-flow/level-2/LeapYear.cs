using System;
class LeapYear
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Year:");
        int Year = Convert.ToInt32(Console.ReadLine());

        if((Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0))
        {
            Console.WriteLine("Leap Year");
        }
        else
        {
            Console.WriteLine("Not Leap Year");
        }
    }
}