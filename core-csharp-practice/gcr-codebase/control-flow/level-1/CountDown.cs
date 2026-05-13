using System;
class CountDown
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        while (number > 0)
        {
            Console.WriteLine(number);
            number--;
        }
    }
}