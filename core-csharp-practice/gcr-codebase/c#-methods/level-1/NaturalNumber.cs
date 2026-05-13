using System;
class NaturalNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number:");
        int n = Convert.ToInt32(Console.ReadLine());

        int sum = SumOfNaturalNumber(n);

        Console.WriteLine("Sum of "+n+" natural number: "+sum);
    }
    static int SumOfNaturalNumber(int n)
    {
        int sum = 0;
        for(int i = 1; i <= n; i++)
        {
            sum = sum + i;
        }
        return sum;
    }
}