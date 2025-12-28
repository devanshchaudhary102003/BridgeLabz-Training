using System;
class Factorial
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Factorial of number: " + IsFactorial(num));
    }

    static long IsFactorial(int n)
    {
        if(n <= 1)
            return 1;

        return n * IsFactorial(n-1);
    }
}