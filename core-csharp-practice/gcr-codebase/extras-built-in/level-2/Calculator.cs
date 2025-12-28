using System;

class Calculator
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("1.Add  2.Subtract  3.Multiply  4.Divide");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1: 
                Console.WriteLine(Add(a, b)); 
                break;
            case 2: 
                Console.WriteLine(Subtract(a, b)); 
                break;
            case 3: 
                Console.WriteLine(Multiply(a, b)); 
                break;
            case 4:
                if (b != 0)
                    Console.WriteLine(Divide(a, b));
                else
                    Console.WriteLine("Division by zero not allowed");
                break;
        }
    }

    static double Add(double x, double y)
    {
        return x + y;
    }
    static double Subtract(double x, double y)
    {
        return x - y;
    }
    static double Multiply(double x, double y)
    {
        return x * y;
    }
    static double Divide(double x, double y)
    {
        return x / y;
    }
}
