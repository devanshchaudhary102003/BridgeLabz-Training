using System;
class PrimeNumberChecker
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        if (IsPrime(num))
        {
            Console.WriteLine("Prime Number");
        }
        else
        {
            Console.WriteLine("Not Prime Number");
        }
    }
    static bool IsPrime(int num)
    {
        if(num <= 1)    return false;

        for(int i = 2; i <= Math.Sqrt(num); i++)
        {
            if(num % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}