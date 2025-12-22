using System;
class CountDown
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        for(int i = number;i >= 1; i--)
        {
            Console.WriteLine(i);
        }
    }
}