using System;
class SumOfNumber2
{
    static void Main(string[] args)
    {

        int ans = 0;
        int number = 1;
        while( true)
        {
            Console.WriteLine("Enter number: ");
            number = Convert.ToInt32(Console.ReadLine());
            ans = ans + number;
            if(number <= 0)
            {
                break;
            }
        }
        Console.WriteLine("Total Value:"+ans);
    }
}