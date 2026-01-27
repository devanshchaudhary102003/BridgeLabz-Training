using System;

class DivisionException
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine());

            int result = num1 / num2;
            Console.WriteLine("Result: " + result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("DivideByZeroException: Cannot divide by zero");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter numeric values only");
        }
    }
}
