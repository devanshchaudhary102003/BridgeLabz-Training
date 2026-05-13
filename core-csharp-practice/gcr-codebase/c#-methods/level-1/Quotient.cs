using System;
class Quotient
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number:");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter a Divisor:");
        int d = Convert.ToInt32(Console.ReadLine());

        int[] result = FindRemainderAndQuotient(n,d);
        Console.WriteLine("Quotient: "+result[0]);
        Console.WriteLine("reminder: "+result[1]);
    }

    public static int[] FindRemainderAndQuotient(int number, int divisor)
    {
        int Quotient = number/divisor;
        int remainder = number%divisor;

        return new int[] { Quotient, remainder };
    }
}