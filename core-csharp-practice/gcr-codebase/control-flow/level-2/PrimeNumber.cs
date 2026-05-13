using System;
class PrimeNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int count = 0;
        for(int i = 2; i <= Number; i++){
            if(Number % i == 0)
            {
                count++;
            }
        }
        if(count == 1)
        {
            Console.WriteLine("Prime Number");
        }
        else
        {
            Console.WriteLine("Not Prime Number");
        }
    }
}