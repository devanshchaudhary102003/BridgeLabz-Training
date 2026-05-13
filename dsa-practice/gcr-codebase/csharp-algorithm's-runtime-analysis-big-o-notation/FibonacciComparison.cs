using System;
using System.Diagnostics;

class FibonacciComparison
{
    // Recursive Fibonacci (O(2^N))
    public static int FibonacciRecursive(int n)
    {
        if (n <= 1)
            return n;

        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    // Iterative Fibonacci (O(N))
    public static int FibonacciIterative(int n)
    {
        if (n <= 1)
            return n;

        int a = 0, b = 1, sum = 0;

        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }

        return b;
    }

    static void Main()
    {
        int[] testValues = { 10, 30 };

        Console.WriteLine("Fibonacci Performance Comparison");
        Console.WriteLine("--------------------------------");

        foreach (int n in testValues)
        {
            Console.WriteLine("\nN = " + n);

            // Recursive Timing
            Stopwatch swRecursive = Stopwatch.StartNew();
            int recResult = FibonacciRecursive(n);
            swRecursive.Stop();

            Console.WriteLine("Recursive Result  : " + recResult);
            Console.WriteLine("Recursive Time    : " + swRecursive.ElapsedMilliseconds + " ms");

            // Iterative Timing
            Stopwatch swIterative = Stopwatch.StartNew();
            int itrResult = FibonacciIterative(n);
            swIterative.Stop();

            Console.WriteLine("Iterative Result  : " + itrResult);
            Console.WriteLine("Iterative Time   : " + swIterative.ElapsedMilliseconds + " ms");
        }

        Console.WriteLine("\nNote:");
        Console.WriteLine("Recursive Fibonacci is impractical for N >= 40 due to exponential time.");
        Console.WriteLine("Iterative Fibonacci works efficiently even for large N.");

        Console.ReadLine();
    }
}
