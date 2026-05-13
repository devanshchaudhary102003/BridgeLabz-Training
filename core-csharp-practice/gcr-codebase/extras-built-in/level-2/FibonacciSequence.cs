using System;
class FibonacciSequence
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of terms: ");
        int n = Convert.ToInt32(Console.ReadLine());

        IsFibonacci(n);
    }
    static void IsFibonacci(int n)
    {
        int a = 0 , b = 1;

        for(int i = 1; i <= n; i++)
        {
            Console.WriteLine(a +" ");
            int next = a + b;
            a = b;
            b = next;
        }
    }
}