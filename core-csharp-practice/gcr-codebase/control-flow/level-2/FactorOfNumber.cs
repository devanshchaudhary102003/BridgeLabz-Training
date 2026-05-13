using System;
class FactorOfNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        for(int i = 1; i <= Number; i++)
        {
            if(Number % i == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}