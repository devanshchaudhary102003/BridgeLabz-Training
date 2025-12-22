using System;
class SumOfNumbers
{
    static void Main(string[] args)
    {

        int ans = 0;
        int number = 1;
        while( number != 0)
        {
            Console.WriteLine("Enter number: ");
            number = Convert.ToInt32(Console.ReadLine());
            ans = ans + number;
        }
        Console.WriteLine("Total Value:"+ans);
    }
}