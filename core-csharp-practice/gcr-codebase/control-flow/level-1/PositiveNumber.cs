using System;
class PositiveNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if(number > 0)
        {
            Console.WriteLine("Positive");
        }
        else if(number < 0)
        {
            Console.WriteLine("Negative");
        }
        else
        {
            Console.WriteLine("Zero");
        }
    }
}