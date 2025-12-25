using System;

class FactorsOfNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = FindFactors(number);

        Console.WriteLine("Factors of " + number + ":");
        for (int i = 0; i < factors.Length; i++)
        {
            Console.WriteLine(factors[i] + " ");
        }

        int sum = FindSumOfFactors(factors);
        double sumOfSquares = FindSumOfSquaresOfFactors(factors);
        long product = FindProductOfFactors(factors);

        Console.WriteLine("Sum of factors: " + sum);
        Console.WriteLine("Sum of squares of factors: " + sumOfSquares);
        Console.WriteLine("Product of factors: " + product);
    }

    public static int[] FindFactors(int number)
    {
        int count = 0;
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                count++;
        }

        int[] factors = new int[count];
        int index = 0;

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                factors[index] = i;
                index++;
            }
        }

        return factors;
    }
    public static int FindSumOfFactors(int[] factors)
    {
        int sum = 0;
        for (int i = 0; i < factors.Length; i++)
        {
            sum += factors[i];
        }
        return sum;
    }

    public static long FindProductOfFactors(int[] factors)
    {
        long product = 1;
        for (int i = 0; i < factors.Length; i++)
        {
            product *= factors[i];
        }
        return product;
    }
    public static double FindSumOfSquaresOfFactors(int[] factors)
    {
        double sum = 0;
        for (int i = 0; i < factors.Length; i++)
        {
            sum += Math.Pow(factors[i], 2);
        }
        return sum;
    }
}
