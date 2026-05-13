using System;
class TemperatureConverter
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Enter Celsius: ");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Fahrenheit = " + CtoF(c));
        }
        else
        {
            Console.Write("Enter Fahrenheit: ");
            double f = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Celsius = " + FtoC(f));
        }
    }

    static double CtoF(double c)
    {
        return (c * 9 / 5) + 32;
    }

    static double FtoC(double f)
    {
        return (f - 32) * 5 / 9;
    }
}